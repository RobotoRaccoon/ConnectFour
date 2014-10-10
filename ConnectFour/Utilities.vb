Public Class Utilities

    '' String function: Extract
    Public Shared Function Extract(intStart As Integer, intFinish As Integer, strExtract As String)
        Dim strTemp = ""
        Dim intPosition = intStart

        While intPosition <= intFinish
            strTemp = strTemp + strExtract(intPosition)
            intPosition += 1
        End While

        Return strTemp

    End Function

    '' String function: Delete
    Public Shared Function Delete(intStart As Integer, intFinish As Integer, strDelete As String)
        Dim strTemp = Extract(1, intStart - 1, strDelete)
        Dim intLength = strDelete.Length()
        strTemp = strTemp + Extract(intFinish + 1, intLength, strDelete)

        Return strTemp

    End Function

    '' String function: Insert
    Public Shared Function Insert(intStart As Integer, strInsert As String, strMain As String)
        Dim strTemp = Extract(1, intStart - 1, strMain)
        strTemp = strTemp + strInsert
        Dim intLength = strMain.Length()
        strTemp = strTemp + Extract(intStart, intLength, strMain)

        Return strTemp

    End Function

    ''Array Function: Find Maximum
    Public Shared Function getMaximum(intList As List(Of Integer))
        Dim intMaxIndex = 0

        For i As Integer = 0 To intList.Count - 1 Step 1

            If intList(i) > intList(intMaxIndex) Then
                intMaxIndex = i
            End If

        Next

        Return intList(intMaxIndex)

    End Function

    ''Array Function: Find Minimum
    Public Shared Function getMinimum(intList As List(Of Integer))
        Dim intMinIndex = 0

        For i As Integer = 0 To intList.Count - 1 Step 1

            If intList(i) < intList(intMinIndex) Then
                intMinIndex = i
            End If

        Next

        Return intList(intMinIndex)

    End Function

    ''Search Function: Linear
    Public Shared Function searchLinear(objList() As Object, objToFind As Object)
        Dim intIndex = Nothing

        For i As Integer = 0 To objList.Length Step 1

            '' If the object is in the list, exit the loop and set the index variable.
            If objList(i) = objToFind Then
                intIndex = i
                Exit For
            End If

        Next

        '' Return False is the object is not in the array, or return the index if it is.
        If intIndex = Nothing Then
            Return False
        Else
            Return intIndex
        End If

    End Function

    ''Sort Function: Ascending Selection
    Public Shared Function sortSelectionAscending(intUnsortedList As List(Of Integer))

        Dim intSortedList As New List(Of Integer)

        While intUnsortedList.Count > 0

            Dim intMin = getMinimum(intUnsortedList)
            intSortedList.Add(intMin)
            intUnsortedList.Remove(intMin)

        End While

        Return intSortedList
    End Function

    ''Sort Function: Descending Selection
    Public Shared Function sortSelectionDescending(intUnsortedList As List(Of Integer))

        Dim intSortedList As New List(Of Integer)

        While intUnsortedList.Count > 0

            Dim intMax = getMaximum(intUnsortedList)
            intSortedList.Add(intMax)
            intUnsortedList.Remove(intMax)

        End While

        Return intSortedList
    End Function

    ''Sort Function: Bubble
    Public Shared Function sortBubble(intList As List(Of Integer))

        Dim booFinished As Boolean = False
        Dim intPass As Integer = 1

        While booFinished = False

            For intCount As Integer = 0 To (intList.Count - intPass - 1)

                If intList(intCount) > intList(intCount + 1) Then
                    Dim intTemp = intList(intCount)
                    intList(intCount) = intList(intCount + 1)
                    intList(intCount + 1) = intTemp
                End If

            Next

            intPass += 1

            If intPass = intList.Count Then
                booFinished = True
            End If

        End While

        Return intList
    End Function

End Class
