using CountTheCharactersBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountTheCharactersBot.Services
{
    public interface IStorage
    {
        Session GetSession(long chatId);
    }
}
