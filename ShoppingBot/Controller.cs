using System;
using System.IO;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace ShoppingBot
{
    public class Controller
    {
        private static ITelegramBotClient m_BotManager;
        private MainFrm m_mainFrm;
        private readonly string r_Key = "1397090921:AAHg4HKgbHNX38_prN01nhS46uL7plqnhJ0";

        public Controller()
        {
           // m_BotManager = new TelegramBotClient("1397090921:AAHg4HKgbHNX38_prN01nhS46uL7plqnhJ0");
         //   var me = m_BotManager.GetMeAsync().Result;
         //   m_BotManager.OnMessage += TBot_OnMessage;
            m_mainFrm = new MainFrm();
            m_mainFrm.ctrl = this; 

        }

        public void StartBot()
        {
            m_BotManager.StartReceiving();
        }
        public void StopBot()
        {
            m_BotManager.StopReceiving();
        }
        public string getCurrentKey()
        {
            return this.r_Key;
        }

        public void Run()
        {
            m_mainFrm.ShowDialog();
        }

        private async void TBot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"recived text : {e.Message.Chat.Id} {e.Message.Text }");

                await m_BotManager.SendTextMessageAsync(chatId: e.Message.Chat, text: "answer!!" + e.Message.Text);
                Console.WriteLine(e.Message.Text);
                File.AppendAllText(@"c:\\1\\text1.txt", e.Message.Text + Environment.NewLine);
                if (e.Message.Text.Contains("ok"))
                {
                    Console.WriteLine("OK!");
                }
            }
        }
    }
}
