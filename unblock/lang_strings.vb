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

Imports System.Globalization
Imports System.Resources
Public Class lang_strings
    Public Function getStr(ByVal str As String) As String
        If CultureInfo.CurrentUICulture.ToString.Contains("ar") = True Then
            Return My.Resources.lang_ar.ResourceManager.GetString(str)
        Else
            Return My.Resources.lang_en.ResourceManager.GetString(str)
        End If
    End Function
End Class
