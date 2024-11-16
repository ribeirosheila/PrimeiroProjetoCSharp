using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Estacionamento.Models
{
    public class OptionList
    {
        // Enum que define as opções do menu
        public enum MenuOptions
        {
            NewCar = 1,
            VerifyCar = 2,
            Payment = 3,
            Finish = 4
        }
    }
}