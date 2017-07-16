using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Threading;

public partial class SendEmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            SendMail();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", ex.Message, false);
        }
        finally
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "Email Sent Successfully", false);
        }
    }

    private void SendMail()
    {
        SmtpClient smtpClient = new SmtpClient();
        MailMessage mail = new MailMessage();
        try
        {
            smtpClient.Credentials = new System.Net.NetworkCredential(
                ConfigurationManager.AppSettings["SenderEmail"],
                ConfigurationManager.AppSettings["SenderPassword"]);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//Email will be sent thru the n/w to an smtp server
            smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PortNo"]);
            smtpClient.Host = Convert.ToString(ConfigurationManager.AppSettings["Host"]);
            smtpClient.EnableSsl = true;

            mail.From = new MailAddress(
                ConfigurationManager.AppSettings["SenderEmail"],
                ConfigurationManager.AppSettings["SenderDisplayName"], System.Text.Encoding.UTF8);
            mail.To.Add(new MailAddress(Convert.ToString(txtTo.Value)));
            if (!string.IsNullOrEmpty(txtCC.Value))
                mail.CC.Add(new MailAddress(Convert.ToString(txtCC.Value)));
            if (!string.IsNullOrEmpty(txtBcc.Value))
                mail.Bcc.Add(new MailAddress(Convert.ToString(txtBcc.Value)));
            mail.Subject = Convert.ToString(txtSubject.Value);
            mail.Body = Convert.ToString(txtBody.Value);
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            smtpClient.Send(mail);
        }
        catch (SmtpFailedRecipientException ex)
        {
            SmtpStatusCode statusCode = ex.StatusCode;

            if (statusCode == SmtpStatusCode.MailboxBusy ||statusCode == SmtpStatusCode.MailboxUnavailable || statusCode == SmtpStatusCode.TransactionFailed)
            {
                Thread.Sleep(5000);
                smtpClient.Send(mail);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}