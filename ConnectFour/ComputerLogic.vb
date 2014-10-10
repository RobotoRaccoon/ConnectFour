Public Class ComputerLogic

    Public Shared intPotentialColumn As Integer = -1
    Public Shared listBannedColumnsHigh As New List(Of Integer)
    Public Shared listBannedColumnsLow As New List(Of Integer)

    Public Shared Function Logic(ByVal intRandom As Integer)

        Dim PlayerMoves As List(Of Integer) = GamePlay.listPlayerMoves
        Dim ComputerMoves As List(Of Integer) = GamePlay.listComputerMoves

        '' Set the multiplier for the random number below depending
        '' on how many moves the player has done.
        Dim intMultiplier As Integer = 3
        If PlayerMoves.Count > 6 Then
            intMultiplier = 5
        End If

        Randomize()
        Try '' Play near where you last went, or in the middle if the Computer goes first.
            intRandom = Int(Rnd() * intMultiplier - (intMultiplier - 1) / 2 + PlayerMoves.Last)
            intRandom = Math.Abs(intRandom) Mod 7
        Catch
            intRandom = 3
        End Try

        Randomize()
        '' Never go on top of you for the first move.
        If PlayerMoves.Count = 1 And ComputerMoves.Count = 0 Then

            If GamePlay.listPlayerMoves.Last = 3 Then

                If Int(Rnd() * 2) = 0 Then
                    intRandom = 2
                Else
                    intRandom = 4
                End If

            Else
                intRandom = 3
            End If

        End If

        '' No need to check rows if only two pieces.
        If PlayerMoves.Count < 2 Or ComputerMoves.Count < 2 Then
            Return intRandom
        End If

        '' Do not run the following code depending on what difficulty was selected.
        '' This uses a random number to determine a chance of running the code.
        '' '' eg. Difficulty 10 has a 100% of running the code, whilst
        '' ''    difficulty 3 only has a 30% chance of running the code.
        Dim intDifficulty As Integer = GameConfig.cbDifficulty.SelectedItem
        Randomize()
        If Int(Rnd() * 10 + 1) > intDifficulty Then
            Return intRandom
        End If

        '''''''''''''''''''''''''''
        ''                       ''
        ''  Start: Row checking  ''
        ''                       ''
        '''''''''''''''''''''''''''

        Dim booAlternativeFound As Boolean = False
        booAlternativeFound = CheckRows()
        Dim listAllowedColumns As New List(Of Integer)

        '' Add all columns that are not full to the original list.
        Dim intLoopCount As Integer = 0
        Do
            If GamePlay.arrField(intLoopCount, 5) = Nothing Then
                listAllowedColumns.Add(intLoopCount)
            End If
            intLoopCount += 1
        Loop While intLoopCount < 7

        '' If good move is found for the computer to play, use it.
        If booAlternativeFound = True And Not intPotentialColumn < 0 Then
            intRandom = intPotentialColumn

            '' If a good move is not found, Pick a random column from the allowed columns.
        ElseIf listBannedColumnsHigh.Contains(intRandom) Or _
            listBannedColumnsLow.Contains(intRandom) Or _
            Not listAllowedColumns.Contains(intRandom) Then

            '' Remove all the high priority banned columns from the allowed list.
            For Each intBanned As Integer In listBannedColumnsHigh
                listAllowedColumns.Remove(intBanned)
            Next

            '' Remove all low priority banned columns from the allowed list.
            For Each intBanned As Integer In listBannedColumnsLow
                listAllowedColumns.Remove(intBanned)
            Next

            '' If the allowed column list is now empty, set it to the low priority banned column list.
            '' If that prioity list is still empty, get one from the banned columns.
            If listAllowedColumns.Count = 0 Then
                listAllowedColumns = listBannedColumnsLow
            End If

            If listAllowedColumns.Count = 0 Then
                listAllowedColumns = listBannedColumnsHigh
            End If

            '' Pick a random column from the allowed column list.
            Randomize()
            intRandom = listAllowedColumns(Int(Rnd() * listAllowedColumns.Count))
        End If

        '' In most cases not needed, but ensures that the value is only between 0 and 6.
        intRandom = Math.Abs(intRandom) Mod 7

        '' Return the new column (Back to the GamePlay.vb form)
        Return intRandom

    End Function

    Public Shared Function CheckRows()

        ''Check the rows for the best move for the computer to play. And return
        ''True if that move is found.
        If CheckComputerRows() = True Then
            Return True

        ElseIf CheckPlayerRows() = True Then
            Return True

        Else
            Return False

        End If

    End Function

    Public Shared Function CheckComputerRows()

        ''Check the four directions for a move (N, E, NW, NE)
        If CheckNorthRows("Computer") = True Then
            Return True
        End If

        If CheckEastRows("Computer") = True Then
            Return True
        End If

        If CheckNorthWestRows("Computer") = True Then
            Return True
        End If

        If CheckNorthEastRows("Computer") = True Then
            Return True
        End If

        Return False

    End Function

    Public Shared Function CheckPlayerRows()

        ''Check the player rows for a move (N, E, NW, NE)
        If CheckNorthRows("Player") = True Then
            Return True
        End If

        If CheckEastRows("Player") = True Then
            Return True
        End If

        If CheckNorthWestRows("Player") = True Then
            Return True
        End If

        If CheckNorthEastRows("Player") = True Then
            Return True
        End If

        Return False

    End Function

    Public Shared Function getPieceToFind(strPlayer As String)

        Dim intToFind As Integer

        Select Case strPlayer
            Case "Computer"
                If GamePlay.intMainPlayer = 1 Then
                    intToFind = 2
                Else
                    intToFind = 1
                End If
            Case "Player"
                If GamePlay.intMainPlayer = 1 Then
                    intToFind = 1
                Else
                    intToFind = 2
                End If

        End Select

        Return intToFind
    End Function

    Public Shared Sub AddBannedColumn(intColumn As Integer, strPlayer As String)

        ''Banned columns = Columns the computer is NOT allowed to play in

        ''Banned columns which the player can win in are of
        ''higher priority than the Computer's columns.
        Select Case strPlayer.ToLower
            Case "player"
                listBannedColumnsHigh.Add(intColumn)

            Case "computer"
                listBannedColumnsLow.Add(intColumn)

        End Select

    End Sub

    Public Shared Function CheckNorthRows(ByVal strPlayer As String)

        '' Get what piece to look for when finding "three's in a row" (Allowing for whitespaces)
        Dim intToFind As Integer = getPieceToFind(strPlayer)
        Dim arrAlreadyChecked(6, 5) As Boolean

        ''Go across all 7 columns, and only look up the first 3 rows (Any higher is useless)
        For y As Integer = 0 To 2
            For x As Integer = 0 To 6

                If GamePlay.arrField(x, y) = intToFind And Not arrAlreadyChecked(x, y) = True Then

                    Dim intInARow As Integer = 1
                    arrAlreadyChecked(x, y) = True
                    For i As Integer = y + 1 To 5

                        If GamePlay.arrField(x, i) = intToFind Then
                            intInARow += 1
                            arrAlreadyChecked(x, i) = True

                            If intInARow = 3 And GamePlay.arrField(x, i + 1) = Nothing Then
                                intPotentialColumn = x
                                Return True
                            End If

                        Else
                            Exit For
                        End If

                    Next

                End If

            Next
        Next

        Return False

    End Function

    Public Shared Function CheckEastRows(ByVal strPlayer As String)

        '' Get what piece to look for when finding "three's in a row" (Allowing for whitespaces)
        Dim intToFind As Integer = getPieceToFind(strPlayer)
        Dim arrAlreadyChecked(6, 5) As Boolean

        ''Go across only the first 5 columns (Any higher is useless), and up all 6 rows.
        For y As Integer = 0 To 5
            For x As Integer = 0 To 4

                If GamePlay.arrField(x, y) = intToFind And Not arrAlreadyChecked(x, y) = True Then

                    Dim intInARow As Integer = 1
                    arrAlreadyChecked(x, y) = True

                    '' Check to see if there is a whitespace to the left.
                    Dim listWhiteSpaces As New List(Of Integer)
                    If Not x = 0 Then
                        If GamePlay.arrField(x - 1, y) = Nothing Then
                            listWhiteSpaces.Add(x - 1)
                        End If
                    End If

                    Dim booSpaceFound As Boolean = False
                    For i As Integer = x + 1 To 6

                        '' Find the amount of pieces in a row, allowing a single white-space
                        If GamePlay.arrField(i, y) = Nothing Then
                            If booSpaceFound = True Then
                                Exit For
                            Else
                                listWhiteSpaces.Add(i)
                                booSpaceFound = True
                            End If

                        ElseIf GamePlay.arrField(i, y) = intToFind Then

                            intInARow += 1

                        Else
                            Exit For
                        End If

                    Next

                    '' If a line of three is found, and a possible position for a piece to go is with it,
                    '' Set the location as the column for the Computer to go.
                    If intInARow >= 3 And listWhiteSpaces.Count > 0 Then

                        For i As Integer = listWhiteSpaces.Count - 1 To 0 Step -1

                            If y = 0 Then
                                intPotentialColumn = listWhiteSpaces(i)
                                Return True
                            ElseIf Not GamePlay.arrField(listWhiteSpaces(i), y - 1) = Nothing Then
                                intPotentialColumn = listWhiteSpaces(i)
                                Return True
                            Else

                                If y - 2 >= 0 Then
                                    If Not GamePlay.arrField(listWhiteSpaces(i), y - 2) = Nothing Then
                                        AddBannedColumn(listWhiteSpaces(i), strPlayer)
                                    End If
                                Else
                                    AddBannedColumn(listWhiteSpaces(i), strPlayer)
                                End If

                            End If

                        Next

                    End If

                End If

            Next
        Next

        Return False

    End Function

    Public Shared Function CheckNorthWestRows(ByVal strPlayer As String)

        '' Get what piece to look for when finding "three's in a row" (Allowing for whitespaces)
        Dim intToFind As Integer = getPieceToFind(strPlayer)
        Dim arrAlreadyChecked(6, 5) As Boolean

        ''Go across only the through columns 3-7 (Any others is useless), and only up the first 4 rows.
        For y As Integer = 0 To 3
            For x As Integer = 2 To 6

                If GamePlay.arrField(x, y) = intToFind And Not arrAlreadyChecked(x, y) = True Then

                    Dim intInARow As Integer = 1
                    arrAlreadyChecked(x, y) = True

                    Dim listWhiteSpaces As New List(Of Integer)
                    If Not x = 6 And Not y = 0 Then
                        If GamePlay.arrField(x + 1, y - 1) = Nothing Then
                            listWhiteSpaces.Add(x + 1)
                        End If
                    End If

                    Dim booSpaceFound As Boolean = False
                    For i As Integer = x - 1 To 0 Step -1
                        Dim intNewY As Integer = y + x - i '' This will decrease by 1 each time. (Yay algebra)

                        If intNewY > 5 Then
                            Exit For
                        End If

                        '' Find the amount of pieces in a row, allowing a single white-space
                        If GamePlay.arrField(i, intNewY) = Nothing Then
                            If booSpaceFound = True Then
                                Exit For
                            Else
                                listWhiteSpaces.Add(i)
                                booSpaceFound = True
                            End If

                        ElseIf GamePlay.arrField(i, intNewY) = intToFind Then

                            intInARow += 1

                        Else
                            Exit For
                        End If

                    Next

                    '' If a line of three is found, and a possible position for a piece to go is with it,
                    '' Set the location as the column for the Computer to go.
                    If intInARow >= 3 And listWhiteSpaces.Count > 0 Then

                        For i As Integer = listWhiteSpaces.Count - 1 To 0 Step -1

                            If listWhiteSpaces(i) = x + 1 And y = 1 Then
                                intPotentialColumn = listWhiteSpaces(i)
                                Return True
                            ElseIf Not GamePlay.arrField(listWhiteSpaces(i), y + x - listWhiteSpaces(i) - 1) = Nothing Then
                                intPotentialColumn = listWhiteSpaces(i)
                                Return True
                            ElseIf strPlayer = "Player" Then

                                If y + x - listWhiteSpaces(i) - 2 >= 0 Then
                                    If Not GamePlay.arrField(listWhiteSpaces(i), y + x - listWhiteSpaces(i) - 2) = Nothing Then
                                        AddBannedColumn(listWhiteSpaces(i), strPlayer)
                                    End If
                                Else
                                    AddBannedColumn(listWhiteSpaces(i), strPlayer)
                                End If

                            End If

                        Next

                    End If

                End If

            Next
        Next

        Return False

    End Function

    Public Shared Function CheckNorthEastRows(ByVal strPlayer As String)

        '' Get what piece to look for when finding "three's in a row" (Allowing for whitespaces)
        Dim intToFind As Integer = getPieceToFind(strPlayer)
        Dim arrAlreadyChecked(6, 5) As Boolean

        ''Go across only the first 5 columns (Any higher is useless), and only up the first 4 rows.
        For y As Integer = 0 To 3
            For x As Integer = 0 To 4

                If GamePlay.arrField(x, y) = intToFind And Not arrAlreadyChecked(x, y) = True Then

                    Dim intInARow As Integer = 1
                    arrAlreadyChecked(x, y) = True

                    Dim listWhiteSpaces As New List(Of Integer)
                    If Not y = 0 And Not x = 0 Then
                        If GamePlay.arrField(x - 1, y - 1) = Nothing Then
                            listWhiteSpaces.Add(x - 1)
                        End If
                    End If

                    Dim booSpaceFound As Boolean = False
                    For i As Integer = x + 1 To 6
                        Dim intNewY As Integer = y + i - x '' This will increase by 1 each time.

                        If intNewY > 5 Then
                            Exit For
                        End If

                        '' Find the amount of pieces in a row, allowing a single white-space
                        If GamePlay.arrField(i, intNewY) = Nothing Then
                            If booSpaceFound = True Then
                                Exit For
                            Else
                                listWhiteSpaces.Add(i)
                                booSpaceFound = True
                            End If

                        ElseIf GamePlay.arrField(i, intNewY) = intToFind Then

                            intInARow += 1

                        Else
                            Exit For
                        End If

                    Next

                    '' If a line of three is found, and a possible position for a piece to go is with it,
                    '' Set the location as the column for the Computer to go.
                    If intInARow >= 3 And listWhiteSpaces.Count > 0 Then

                        For i As Integer = listWhiteSpaces.Count - 1 To 0 Step -1

                            If listWhiteSpaces(i) = x - 1 And y = 1 Then
                                intPotentialColumn = listWhiteSpaces(i)
                                Return True
                            ElseIf Not GamePlay.arrField(listWhiteSpaces(i), y + listWhiteSpaces(i) - x - 1) = Nothing Then
                                intPotentialColumn = listWhiteSpaces(i)
                                Return True
                            ElseIf strPlayer = "Player" Then

                                If y + listWhiteSpaces(i) - x - 2 >= 0 Then
                                    If Not GamePlay.arrField(listWhiteSpaces(i), y + listWhiteSpaces(i) - x - 2) = Nothing Then
                                        AddBannedColumn(listWhiteSpaces(i), strPlayer)
                                    End If
                                Else
                                    AddBannedColumn(listWhiteSpaces(i), strPlayer)
                                End If

                            End If

                        Next

                    End If

                End If

            Next
        Next

        Return False

    End Function

End Class
