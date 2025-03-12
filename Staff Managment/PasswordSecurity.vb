Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Public Class PasswordSecurity

    ' 🟢 Function to Derive an AES Key from the Master Key
    Public Shared Function GetAESKeyFromMasterKey(masterKey As String) As Byte()
        Return Convert.FromBase64String(masterKey)
    End Function

    ' 🟢 Function to Encrypt a String and Return a Base64 Encoded String
    Public Shared Function EncryptStringToBase64(inputString As String, masterKey As String) As String
        Dim key As Byte() = GetAESKeyFromMasterKey(masterKey)

        ' Generate IV
        Dim iv As Byte() = New Byte(15) {} ' AES block size is 16 bytes
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(iv)
        End Using

        ' Convert input string to bytes
        Dim plainBytes As Byte() = Encoding.UTF8.GetBytes(inputString)

        Using aes As Aes = Aes.Create()
            aes.Key = key
            aes.IV = iv
            aes.Mode = CipherMode.CBC
            aes.Padding = PaddingMode.PKCS7

            Using encryptor As ICryptoTransform = aes.CreateEncryptor()
                Dim encryptedBytes As Byte() = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length)

                ' Store IV + Encrypted Data, return as Base64 string
                Dim finalData As Byte() = iv.Concat(encryptedBytes).ToArray()
                Return Convert.ToBase64String(finalData)
            End Using
        End Using
    End Function

    ' 🟢 Function to Decrypt a Base64 Encoded String
    Public Shared Function DecryptBase64ToString(encryptedBase64 As String, masterKey As String) As String
        Dim key As Byte() = GetAESKeyFromMasterKey(masterKey)

        ' Convert Base64 string to byte array
        Dim encryptedBytes As Byte() = Convert.FromBase64String(encryptedBase64)

        ' Extract IV (first 16 bytes)
        Dim iv As Byte() = encryptedBytes.Take(16).ToArray()

        ' Extract actual encrypted data (remaining bytes)
        Dim cipherBytes As Byte() = encryptedBytes.Skip(16).ToArray()

        Using aes As Aes = Aes.Create()
            aes.Key = key
            aes.IV = iv
            aes.Mode = CipherMode.CBC
            aes.Padding = PaddingMode.PKCS7

            Using decryptor As ICryptoTransform = aes.CreateDecryptor()
                Dim decryptedBytes As Byte() = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length)

                ' Convert decrypted bytes to string and return
                Return Encoding.UTF8.GetString(decryptedBytes)
            End Using
        End Using
    End Function


    ' 🟢 Function to Derive an AES Encryption Key from the Password
    Public Shared Function DeriveEncryptionKey(password As String) As Byte()
        Using sha256 As SHA256 = SHA256.Create()
            Dim salt As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password & "secure_salt"))
            Using pbkdf2 As New Rfc2898DeriveBytes("shared_secret", salt, 100000, HashAlgorithmName.SHA256)
                Return pbkdf2.GetBytes(32) ' 256-bit key for AES
            End Using
        End Using
    End Function

    ' 🟢 Function to Encrypt the Master Key Using AES-256
    Public Shared Function EncryptMasterKey(masterKey As String, password As String) As String
        Dim key As Byte() = DeriveEncryptionKey(password)

        ' Generate IV
        Dim iv As Byte() = New Byte(15) {}
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(iv)
        End Using

        ' Encrypt
        Using aes As Aes = Aes.Create()
            aes.Key = key
            aes.IV = iv
            aes.Mode = CipherMode.CBC
            aes.Padding = PaddingMode.PKCS7

            Dim plainBytes As Byte() = Encoding.UTF8.GetBytes(masterKey)
            Using encryptor As ICryptoTransform = aes.CreateEncryptor()
                Dim encryptedBytes As Byte() = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length)

                ' Store IV + Encrypted Master Key
                Dim finalData As Byte() = iv.Concat(encryptedBytes).ToArray()
                Return Convert.ToBase64String(finalData)
            End Using
        End Using
    End Function

    ' 🟢 Function to Decrypt the Master Key Using AES-256
    Public Shared Function DecryptMasterKey(encryptedMasterKey As String, password As String) As String
        Dim key As Byte() = DeriveEncryptionKey(password)

        ' Decode Base64
        Dim fullCipher As Byte() = Convert.FromBase64String(encryptedMasterKey)

        ' Extract IV and encrypted data
        Dim iv As Byte() = fullCipher.Take(16).ToArray()
        Dim encryptedData As Byte() = fullCipher.Skip(16).ToArray()

        ' Decrypt
        Using aes As Aes = aes.Create()
            aes.Key = key
            aes.IV = iv
            aes.Mode = CipherMode.CBC
            aes.Padding = PaddingMode.PKCS7

            Using decryptor As ICryptoTransform = aes.CreateDecryptor()
                Dim decryptedBytes As Byte() = decryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length)
                Return Encoding.UTF8.GetString(decryptedBytes)
            End Using
        End Using
    End Function
End Class

Public Class UserManager
    Private Shared userFilePath As String = Application.StartupPath + "users.dat"

    Public Shared Sub ManageEncryptionKey(username As String, encryptionKey As String)
        Dim updated As Boolean = False

        ' Ensure file exists
        If Not File.Exists(userFilePath) Then
            File.Create(userFilePath).Dispose()
        End If

        ' Read all lines and check if key exists
        Dim lines As List(Of String) = File.ReadAllLines(userFilePath).ToList()

        For i As Integer = 0 To lines.Count - 1
            If lines(i).StartsWith(username & ":") Then
                ' Update existing key
                lines(i) = username & ":" & encryptionKey
                updated = True
                Exit For
            End If
        Next

        ' If no existing key, create new entry
        If Not updated Then
            lines.Add(username & ":" & encryptionKey)
        End If

        ' Write back to file
        File.WriteAllLines(userFilePath, lines)
    End Sub


    ' 🟢 Function to Add a New User with a Password
    Public Shared Sub AddUser(username As String, password As String)
        Dim masterKey As String = GenerateMasterKey() ' Generate a master key for database encryption
        Dim encryptedMasterKey As String = PasswordSecurity.EncryptMasterKey(masterKey, password)

        ' Save to file
        Dim newUser As String = $"{username}:{encryptedMasterKey}"
        File.AppendAllText(userFilePath, newUser & Environment.NewLine)
    End Sub

    Public Shared Sub RemoveUser(username As String)
        ' Check if the file exists
        If Not File.Exists(userFilePath) Then
            MessageBox.Show("User file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Read all lines and filter out the user
        Dim lines As List(Of String) = File.ReadAllLines(userFilePath).ToList()
        Dim updatedLines = lines.Where(Function(line) Not line.StartsWith(username & ":")).ToList()

        ' Check if the user was found and removed
        If lines.Count = updatedLines.Count Then
            MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Overwrite the file with updated user list
        File.WriteAllLines(userFilePath, updatedLines)

        ' Confirmation message
        MessageBox.Show($"User '{username}' has been removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' 🟢 Function to Retrieve the Encrypted Master Key for a Username
    Public Shared Function GetEncryptedMasterKey(username As String) As String
        If File.Exists(userFilePath) Then
            For Each line As String In File.ReadAllLines(userFilePath)
                Dim parts As String() = line.Split(":"c)
                If parts(0).ToLower() = username.ToLower() Then
                    Return parts(1) ' Return encrypted master key
                End If
            Next
        End If
        Return Nothing ' User not found
    End Function

    ' 🟢 Function to Generate a Random 256-bit Master Key
    Private Shared Function GenerateMasterKey() As String
        Dim key As Byte() = New Byte(31) {} ' 32 bytes for AES-256
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(key)
        End Using
        Return Convert.ToBase64String(key)
    End Function
End Class