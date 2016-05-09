'This file is part of UnblockDoom.
'
'UnblockDoom is free software: you can redistribute it and/or modify
'it under the terms of the GNU General Public License as published by
'the Free Software Foundation, either version 3 of the License, or
'(at your option) any later version.
'
'UnblockDoom is distributed in the hope that it will be useful,
'but WITHOUT ANY WARRANTY; without even the implied warranty of
'MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'GNU General Public License for more details.
'
'You should have received a copy of the GNU General Public License
'along with UnblockDoom.  If not, see <http://www.gnu.org/licenses/>.

Public Class Form2
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.Opacity <= 1.0 Then
            Me.Opacity = Me.Opacity - 0.01
        End If
        If Me.Opacity <= 0.01 Then
            Timer1.Stop()
            Me.Hide()
        End If
    End Sub
End Class