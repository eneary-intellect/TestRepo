Module Module1

    Sub Main()

        testMobileSaveApiParsing()
    End Sub


    Public Sub testMobileSaveApiParsing()

        Dim TempValue As String = ""

        'Dim OldValue As String = "<table cellpadding='0' cellspacing='3' width='100%'><tr><td colspan='3' width='100%'><span style='font-size:12px;font-weight:bold'>test</span></td></tr><tr><td nowrap><img src='/Intellect/Skins/Default/Images/UserIcon.gif' /></td><td nowrap width='100%'>Erika Fahey</td><td nowrap>5/10/2020 11:38:12 PM</td></tr><td colspan='3' width='100%' bgcolor='#000000' height='1px'></td></table>tt<br /><br /><table cellpadding='0' cellspacing='3' width='100%'><tr><td colspan='3' width='100%'><span style='font-size:12px;font-weight:bold'>test</span></td></tr><tr><td nowrap><img src='/Intellect/Skins/Default/Images/UserIcon.gif' /></td><td nowrap width='100%'>Erika Fahey</td><td nowrap>5/10/2020 11:37:51 PM</td></tr><td colspan='3' width='100%' bgcolor='#000000' height='1px'></td></table>test<br /><br />missed student upload deadline"
        Dim OldValue As String = "<table cellpadding=&apos;0&apos; cellspacing=&apos;3&apos; width=&apos;100%&apos;><tr><td colspan=&apos;3&apos; width=&apos;100%&apos;><span style=&apos;font-size:12px;font-weight:bold&apos;>ahmad</span></td></tr><tr><td nowrap><img src=&apos;/Intellect/Skins/ Default /Images/UserIcon.gif&apos; /></td><td nowrap width=&apos;100%&apos;>administrator</td><td nowrap>03/09/22</td></tr><td colspan=&apos;3&apos; width=&apos;100%&apos; bgcolor=&apos;#000000&apos; height=&apos;1px&apos;></td></table>ahmad<br /><br /><table cellpadding=&apos;0&apos; cellspacing=&apos;3&apos; width=&apos;100%&apos;><tr><td colspan=&apos;3&apos; width=&apos;100%&apos;><span style=&apos;font-size:12px;font-weight:bold&apos;>subject</span></td></tr><tr><td nowrap><img src=&apos;/Intellect/Skins/ Default /Images/UserIcon.gif&apos; /></td><td nowrap width=&apos;100%&apos;>administrator</td><td nowrap>01/09/22</td></tr><td colspan=&apos;3&apos; width=&apos;100%&apos; bgcolor=&apos;#000000&apos; height=&apos;1px&apos;></td></table>comment<br /><br />~\t~lt;Entry~\t~gt;~\t~lt;Subject~\t~gt;Subject2~\t~lt;/Subject~\t~gt;~\t~lt;CreatedBy~\t~gt;Mr., Designer~\t~lt;/CreatedBy~\t~gt;~\t~lt;CreatedOn~\t~gt;7/15/2022 8:40:18 AM~\t~lt;/CreatedOn~\t~gt;~\t~lt;Body~\t~gt;Body2~\t~lt;/Body~\t~gt;~\t~lt;/Entry~\t~gt;~\t~lt;Entry~\t~gt;~\t~lt;Subject~\t~gt;Subject1~\t~lt;/Subject~\t~gt;~\t~lt;CreatedBy~\t~gt;Mr., Designer~\t~lt;/CreatedBy~\t~gt;~\t~lt;CreatedOn~\t~gt;7/15/2022 8:40:04 AM~\t~lt;/CreatedOn~\t~gt;~\t~lt;Body~\t~gt;Body1~\t~lt;/Body~\t~gt;~\t~lt;/Entry~\t~gt;</Value><LinkTo ID=""1000016688"">1000016688</LinkTo>
</Item>"

        Dim SubjectTags As String = "<table cellpadding=&apos;0&apos; cellspacing=&apos;3&apos; width=&apos;100%&apos;><tr><td colspan=&apos;3&apos; width=&apos;100%&apos;><span style=&apos;font-size:12px;font-weight:bold&apos;>"
        Dim CreatedByTags As String = "</span></td></tr><tr><td nowrap><img src=&apos;/Intellect/Skins/Default/Images/UserIcon.gif&apos; /></td><td nowrap width=&apos;100%&apos;>"
        Dim CreatedOnTags As String = "</td><td nowrap>"
        Dim BodyTags As String = "</td></tr><td colspan=&apos;3&apos; width=&apos;100%&apos; bgcolor=&apos;#000000&apos; height=&apos;1px&apos;></td></table>"
        Dim SubjectTagsPos As Long = OldValue.IndexOf(SubjectTags)
        Dim CreatedByTagsPos As Long
        Dim CreatedOnTagsPos As Long
        Dim BodyTagsPos As Long
        Dim Subject As String
        Dim CreatedBy As String
        Dim CreatedOn As String
        Dim Body As String
        TempValue = ""
        While SubjectTagsPos <> -1
            OldValue = OldValue.Substring(SubjectTags.Length)
            CreatedByTagsPos = OldValue.IndexOf(CreatedByTags)
            If CreatedByTagsPos = -1 Then
                OldValue = OldValue.Replace("Skins/ Default /Images", "Skins/Default/Images")
                CreatedByTagsPos = OldValue.IndexOf(CreatedByTags)
            End If
            Subject = OldValue.Substring(0, CreatedByTagsPos)
            OldValue = OldValue.Substring(CreatedByTagsPos + CreatedByTags.Length)
            CreatedOnTagsPos = OldValue.IndexOf(CreatedOnTags)
            CreatedBy = OldValue.Substring(0, CreatedOnTagsPos)
            OldValue = OldValue.Substring(CreatedOnTagsPos + CreatedOnTags.Length)
            BodyTagsPos = OldValue.IndexOf(BodyTags)
            CreatedOn = OldValue.Substring(0, BodyTagsPos)
            OldValue = OldValue.Substring(BodyTagsPos + BodyTags.Length)
            SubjectTagsPos = OldValue.IndexOf(SubjectTags)
            If SubjectTagsPos = -1 Then
                Body = OldValue
            Else
                Body = OldValue.Substring(0, SubjectTagsPos)
                OldValue = OldValue.Substring(SubjectTagsPos)
            End If
            TempValue += $"<Entry><Subject>{Subject.Replace("&", "&amp;")}</Subject><CreatedBy>{CreatedBy.Replace("&", "&amp;")}</CreatedBy><CreatedOn>{CreatedOn.Replace("&", "&amp;")}</CreatedOn><Body>{Body.Replace("<br>", "<br/>").Replace("&", "&amp;")}</Body></Entry>"
        End While


    End Sub


End Module
