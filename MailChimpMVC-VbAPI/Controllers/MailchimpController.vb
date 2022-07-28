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



        Async Function AddSubscribeUserAsync(frc As FormCollection) As Task(Of ActionResult)

            Dim userEmail As String = frc.Get("subscribe")

            Dim manager As IMailChimpManager = New MailChimpManager("Yout API Key")

            Dim listId As String = "Your List ID"

            Dim member As Member = New Member()
            member.EmailAddress = userEmail

            Await manager.Members.AddOrUpdateAsync(listId, member)

            Dim response As Response = New Response()
            response.message = "Thank you, you has just subscribed into the system"

            Return View("~/Views/Home/Index.vbhtml", response)

        End Function



    End Class
End Namespace
