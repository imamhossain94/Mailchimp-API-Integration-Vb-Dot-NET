Imports System.Threading.Tasks
Imports MailChimp.Net
Imports MailChimp.Net.Core
Imports MailChimp.Net.Interfaces
Imports MailChimp.Net.Models
Imports DotLiquid


Namespace Controllers
    Public Class MailchimpController
        Inherits Controller

        ' GET: Mailchimp
        Function Index() As ActionResult
            Return View()
        End Function

        ' create an instance of MailChimpManager
        ' put the API key into the constructor of the MailChimpManager
        Dim manager As IMailChimpManager = New MailChimpManager("YourApiKey")

        Async Function AddSubscribeUserAsync(frc As FormCollection) As Task

            Try
                Dim listId As String = "e1ef29fa49"
                Dim userEmail As String = frc.Get("subscribe")
                Dim member As Member = New Member()
                member.EmailAddress = userEmail

                Await manager.Members.AddOrUpdateAsync(listId, member)

                Response.Write("<script>alert('Thank you, you has just subscribed into the system');</script>")
            Catch ex As Exception
                Response.Write("<script>alert('Something wents wrong!');</script>")
            End Try

        End Function


        Public Async Function GetAudienceList() As Task(Of IEnumerable(Of List))

            Dim result = Await manager.Lists.GetAllAsync().ConfigureAwait(False)
            Return result

        End Function

        Public Async Function GetContactsList(listId As String) As Task(Of IEnumerable(Of Member))

            Dim result = Await manager.Members.GetAllAsync(listId).ConfigureAwait(False)
            Return result

        End Function


        Public Async Function GetGroupList(listId As String) As Task(Of IEnumerable(Of InterestCategory))

            Dim result = Await manager.InterestCategories.GetAllAsync(listId).ConfigureAwait(False)
            Return result

        End Function


        Public Async Function GetGroupCatrgoriesList(listId As String, groupId As String) As Task(Of IEnumerable(Of Interest))

            Dim result = Await manager.Interests.GetAllAsync(listId, groupId).ConfigureAwait(False)
            Return result

        End Function


        Public Async Function AddOrUpdateContact(frc As FormCollection) As Task

            Dim firstName As String = frc.Get("firstName")
            Dim lastName As String = frc.Get("lastName")
            Dim emailAddress As String = frc.Get("emailAddress")
            Dim audieancesId As String = frc.Get("audieancesId")
            Dim categoriesId As String = frc.Get("categoriesId")
            Dim member As Member = New Member()
            member.EmailAddress = emailAddress
            member.Status = Status.Subscribed
            member.MergeFields.Add("FNAME", firstName)
            member.MergeFields.Add("LNAME", lastName)
            ' Add member into a group category
            member.Interests.Add(categoriesId, True)
            Await manager.Members.AddOrUpdateAsync(audieancesId, member)

        End Function

        Public Async Function SendEmail(frc As FormCollection) As Task(Of Boolean)

            ' Get values from the form
            Dim categoriesId As String = frc.Get("categoriesId")
            Dim replyFrom As String = frc.Get("replyFrom")
            Dim campaignTitle As String = frc.Get("campaignTitle")
            Dim emailSubject As String = frc.Get("emailSubject")
            Dim emailBody As String = frc.Get("emailBody")
            Dim audieancesId As String = frc.Get("audieancesId")


            If audieancesId IsNot Nothing Then

                'Get segments list
                Dim result = Await manager.ListSegments.GetAllAsync(audieancesId).ConfigureAwait(False)
                Dim segment As ListSegment = result.ElementAt(0)


                Dim campaignSettings As Setting = New Setting With {
                    .ReplyTo = "softengr1.masleap@gmail.com",
                    .FromName = replyFrom,
                    .Title = campaignTitle,
                    .SubjectLine = emailSubject
                }

                ' create the campaign into MailChimp
                Dim campaign = Await manager.Campaigns.AddAsync(
                    New Campaign With {
                        .Settings = campaignSettings,
                        .Recipients = New Recipient With {
                            .ListId = audieancesId,
                            .SegmentText = segment.Name,
                            .SegmentOptions = segment.Options
                        },
                        .Type = CampaignType.Regular
                    }).ConfigureAwait(False)


                Dim defaultEmailTemplate As String = "<h1>{{Heading}}</h1><p>Dear {{UserName}}, Rich Text Editor is a full-featured Javascript WYSIWYG HTML editor. It enables content contributors easily create and publish HTML anywhere: on the desktop and on mobile.</p><h4>Key features:</h4><ul><li>Built-in image handling &amp; storage</li><li>File drag &amp; drop</li><li>Table Insert</li><li>Provides a fully customizable toolbar</li><li>Paste from Word, Excel and Google Docs</li><li>Mobile Device Support</li></ul>"
                Dim bodyTemplate As DotLiquid.Template = DotLiquid.Template.Parse(defaultEmailTemplate)

                Dim bodyDto = New With {
                    Key .Heading = IIf(emailBody Is Nothing, "What is Rich Text Editor?", emailBody),
                    Key .UserName = "Receiver"
                }
                Dim bodyText As String = bodyTemplate.Render(Hash.FromAnonymousObject(bodyDto))

                ' add cointent into the created campaign
                Await manager.Content.AddOrUpdateAsync(
                    campaign.Id, New ContentRequest With {
                        .Html = bodyText
                    })


                ' Finally send the campaign to the recipient
                Await manager.Campaigns.SendAsync(campaign.Id)

                Return True

            End If

            Return False

        End Function

    End Class
End Namespace
