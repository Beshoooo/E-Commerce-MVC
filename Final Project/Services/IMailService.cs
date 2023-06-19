using Final_Project.Models;


namespace Final_Project.Services
{
    public interface IMailService
    {
        bool SendMail(MailData mailData);
    }
}
