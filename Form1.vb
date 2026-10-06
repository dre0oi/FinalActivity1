Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Limit the text box to 100 characters (same as VARCHAR(100))
        txtInput.MaxLength = 100

        ' 1. Populate the ComboBox options
        cmbOptions.Items.Add("Manager")
        cmbOptions.Items.Add("Developer")
        cmbOptions.Items.Add("Designer")

        If cmbOptions.Items.Count > 0 Then
            cmbOptions.SelectedIndex = 0
        End If

        ' 2. Load existing records from FormData.csv into the ListBox
        LoadCsvToListBox()
    End Sub

    ''' <summary>
    ''' Checks that the text contains only letters and spaces, maximum 100 characters
    ''' </summary>
    Private Function IsValidText(value As String) As Boolean

        ' Must be 100 characters or fewer
        If value.Length > 100 Then
            Return False
        End If

        ' Only letters and spaces are allowed (no numbers or special characters)
        For Each character As Char In value
            If Not Char.IsLetter(character) AndAlso character <> " "c Then
                Return False
            End If
        Next

        Return True
    End Function

    ''' <summary>
    ''' Blocks numbers and special characters while typing.
    ''' Only letters, spaces, and Backspace are allowed.
    ''' </summary>
    Private Sub txtInput_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInput.KeyPress

        If Not Char.IsLetter(e.KeyChar) AndAlso
           Not Char.IsControl(e.KeyChar) AndAlso
           e.KeyChar <> " "c Then

            e.Handled = True

        End If

    End Sub

    ''' <summary>
    ''' Reads FormData.csv from Documents and populates the ListBox
    ''' </summary>
    Private Sub LoadCsvToListBox()
        Dim folderPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim filePath As String = System.IO.Path.Combine(folderPath, "FormData.csv")

        Try
            ' Clear any existing items in the ListBox first
            lstData.Items.Clear()

            ' If the file exists, read each line and add it to the ListBox
            If System.IO.File.Exists(filePath) Then
                ' Using FileShare.ReadWrite so it opens even if Excel or Dropbox has it open for reading
                Using fs As New System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite)
                    Using reader As New System.IO.StreamReader(fs)
                        While Not reader.EndOfStream
                            Dim line As String = reader.ReadLine()
                            If Not String.IsNullOrWhiteSpace(line) Then
                                lstData.Items.Add(line)
                            End If
                        End While
                    End Using
                End Using
            End If

        Catch ex As Exception
            MessageBox.Show("Could not load existing CSV data: " & ex.Message, "Error Loading File", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' 1. Validate input
        If String.IsNullOrWhiteSpace(txtInput.Text) Then
            MessageBox.Show("Please enter some text in the text box.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtInput.Focus()
            Exit Sub
        End If

        ' Check letters and spaces only (no numbers or special characters), max 100
        If Not IsValidText(txtInput.Text.Trim()) Then
            MessageBox.Show("Text can only contain letters and spaces (maximum 100 characters).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtInput.Focus()
            Exit Sub
        End If

        ' 2. Gather data
        Dim textValue As String = txtInput.Text.Trim()
        Dim comboValue As String = If(cmbOptions.SelectedItem IsNot Nothing, cmbOptions.SelectedItem.ToString(), "")
        Dim checkValue As Boolean = chkActive.Checked

        ' 3. Format row
        Dim rowData As String = $"{textValue},{comboValue},{checkValue}"

        ' 4. Add to ListBox
        lstData.Items.Add(rowData)

        ' 5. Save to file using retry/stream logic
        Dim folderPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim filePath As String = System.IO.Path.Combine(folderPath, "FormData.csv")

        Try
            Using fs As New System.IO.FileStream(filePath, System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite)
                Using writer As New System.IO.StreamWriter(fs)
                    writer.WriteLine(rowData)
                End Using
            End Using

            MessageBox.Show("Data successfully saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Clear inputs
            txtInput.Clear()
            chkActive.Checked = False
            If cmbOptions.Items.Count > 0 Then cmbOptions.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show("An error occurred while saving: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' 1. Ensure an item is selected
        If lstData.SelectedIndex = -1 Then
            MessageBox.Show("Please select an item from the list to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 2. Prompt for confirmation
        Dim confirmResult As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirmResult = DialogResult.Yes Then
            Try
                ' 3. Remove selected item from ListBox
                lstData.Items.RemoveAt(lstData.SelectedIndex)

                ' 4. Overwrite CSV file with remaining ListBox items
                Dim folderPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                Dim filePath As String = System.IO.Path.Combine(folderPath, "FormData.csv")

                Dim allLines As New List(Of String)
                For Each item As Object In lstData.Items
                    allLines.Add(item.ToString())
                Next

                ' Write back to file with shared access
                Using fs As New System.IO.FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite)
                    Using writer As New System.IO.StreamWriter(fs)
                        For Each line As String In allLines
                            writer.WriteLine(line)
                        Next
                    End Using
                End Using

                MessageBox.Show("Record deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("An error occurred while updating the file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

End Class