using System;
using System.Net.Mail;

namespace Portfolio.Utility
{
    public static class EmailService
    {
        public static bool SendEmail(string sender,string name, string phone, string content)
        {
            var returnValue = false;
            MailMessage mail = new MailMessage();
            try
            {
                // 보내는 사람 메일, 이름, 인코딩(UTF-8)
                mail.From = new MailAddress("sangbong.bak@gmail.com", name, System.Text.Encoding.UTF8);
                // 받는 사람 메일
                mail.To.Add("goorooru@gmail.com");
                // 참조 사람 메일
                mail.CC.Add("sangbong.park@outlook.com");
                // 비공개 참조 사람 메일
                //mail.Bcc.Add("nowonbun@gmail.com");
                // 메일 제목
                mail.Subject = $"[Portfolio] From {sender} : Name :{name}";
                // 본문 내용
                mail.Body = $"Phone : {phone} \n Name : {name} \n Email : {sender} \n Message : {content} \n";
                // 본문 내용 포멧의 타입 (true의 경우 Html 포멧으로)
                mail.IsBodyHtml =false;
                // 메일 제목과 본문의 인코딩 타입(UTF-8)
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                // 첨부 파일 (Stream과 파일 이름)
                
                // smtp 서버 주소
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                // smtp 포트
                SmtpServer.Port = 587;
                // smtp 인증
                SmtpServer.Credentials = new System.Net.NetworkCredential("sangbong.bak", "!1Qqkrtkdqhd");
                // SSL 사용 여부
                SmtpServer.EnableSsl = true;
                // 발송
                SmtpServer.Send(mail);

                returnValue = true;
            }
            catch (Exception)
            {
                returnValue = false;
            }
            finally
            {
                // 첨부 파일 Stream 닫기
                foreach (var attach in mail.Attachments)
                {
                    attach.ContentStream.Close();
                }
            }

            return returnValue;
        }
    }
}
