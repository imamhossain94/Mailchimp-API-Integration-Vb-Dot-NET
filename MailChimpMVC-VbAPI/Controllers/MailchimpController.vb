Imports System.Threading.Tasks
Imports MailChimp.Net
Imports MailChimp.Net.Interfaces
Imports MailChimp.Net.Models

Namespace Controllers
    Public Class MailchimpController
        Inherits Controller

        ' GET: Mailchimp
        Function Index() As ActionResult
            Return View()
        End Function

        Dim manager As IMailChimpManager = New MailChimpManager("YourApiKey")

        Async Function AddSubscribeUserAsync(frc As FormCollection) As Task(Of ActionResult)

            Dim userEmail As String = frc.Get("subscribe")

            Dim listId As String = "e1ef29fa49"

            Dim member As Member = New Member()
            member.EmailAddress = userEmail

            Await manager.Members.AddOrUpdateAsync(listId, member)

            Dim response As Response = New Response()
            response.message = "Thank you, you has just subscribed into the system"

            Return View("~/Views/Home/Index.vbhtml", response)

        End Function


        Public Async Function GetAudienceList() As Task(Of IEnumerable(Of List))

            Dim mailChimpListCollection = Await manager.Lists.GetAllAsync().ConfigureAwait(False)
            Return mailChimpListCollection

        End Function

        Async Function GetContactsList(frc As FormCollection) As Task(Of ActionResult)

            Try
                Dim listId As String = frc.Get("audiences_id")
                Dim mailChimpContactCollection = Await manager.Members.GetAllAsync(listId).ConfigureAwait(False)

                Return View("~/Views/Home/Users.vbhtml", mailChimpContactCollection)
            Catch ex As Exception
                Response.Write("<script>alert('No contact found!');</script>")
                Return View("~/Views/Home/Users.vbhtml")
            End Try

        End Function


    End Class
End Namespace
