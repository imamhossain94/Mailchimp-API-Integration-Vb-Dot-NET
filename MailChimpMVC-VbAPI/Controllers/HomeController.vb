﻿
Imports System.Threading.Tasks
Imports MailChimp.Net
Imports MailChimp.Net.Interfaces
Imports MailChimp.Net.Models



Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function



    Async Function AddSubscribeUserAsync(frc As FormCollection) As Task(Of ActionResult)

        Dim userEmail As String = frc.Get("subscribe")

        Dim manager As IMailChimpManager = New MailChimpManager("d5b07ad63af25b2df3f3c596f2387bb0-us8")

        Dim listId As String = "e1ef29fa49"

        Dim member As Member = New Member()
        member.EmailAddress = "userEmail"

        Await manager.Members.AddOrUpdateAsync(listId, member)

        Dim response As Response = New Response()
        Response.message = "Thank you, you has just subscribed into the system"

        Return View("~/Views/Home/Contact.cshtml", response)

    End Function

End Class