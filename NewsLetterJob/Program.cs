// See https://aka.ms/new-console-template for more information
using NewsLetterJob.BL;
using System.Linq;
using System.Net;
using System.Net.Mail;

Console.WriteLine("NewsLetter START!");

sendMail();

void sendMail()
{
    Console.WriteLine("====> Trimitere mail ====>");

    var smtpClient = new SmtpClient("smtp.freesmtpservers.com") 
    {
        Port=25,
        //Credentials=new NetworkCredential("iosipoi@gmail.com", "xxxxxx"),
        //EnableSsl=false,
    };

    var bd = new DbManager();

    var mailMessage = new MailMessage
    {
        From = new MailAddress("admin@emagazin.com"),
        Subject = "Produse la promotie",
        Body = bd.GetMessageBody(),
        IsBodyHtml = true,
    };

    var emailsList = bd.GetEmailsList();
    foreach (var email in emailsList)
    {
        mailMessage.To.Add(email);
    }

    smtpClient.Send(mailMessage);   
}


