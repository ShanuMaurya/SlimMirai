﻿using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mirai.Management
{
    class Commands
    {
        internal static async Task Shutdown(ulong User, Queue<string> Args)
        {
            //Save State
            Program.Live = false;
        }

        internal static async Task Voice(string s, SocketMessage e)
        {
            var Values = new Queue<string>(s.Split(' '));
            var Rank = User.GetRank(e.Author.Id);
            var Cmd = Command.GetVoice(string.Join(" ", Values), Rank);
            if (Cmd == null)
            {
                Command.GetVoice(Values.Dequeue(), Rank)?.Invoke(e.Author.Id, Values);
            }
            else
            {
                Values.Clear();
                Cmd.Invoke(e.Author.Id, Values);
            }
        }

        internal static async Task Name(string s, SocketMessage e)
        {
            Bot.User.ModifyAsync(x => x.Username = s);
        }
    }
}
