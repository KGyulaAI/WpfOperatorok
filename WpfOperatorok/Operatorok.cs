using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfOperatorok
{
    class Operatorok
    {
        int elsoOperandus;
        string szovegesOperator;
        int masodikOperandus;

        public Operatorok(int elsoOperandus, string szovegesOperator, int masodikOperandus)
        {
            this.elsoOperandus = elsoOperandus;
            this.szovegesOperator = szovegesOperator;
            this.masodikOperandus = masodikOperandus;
        }

        public int ElsoOperandus { get => elsoOperandus; }
        public string SzovegesOperator { get => szovegesOperator; }
        public int MasodikOperandus { get => masodikOperandus; }

        //6. feladat
        public static string Szamitas(int elsoOperandus, string szovegesOperator, int masodikOperandus)
        {
            try
            {
                switch (szovegesOperator)
                {
                    case "mod":
                        return $"{elsoOperandus % masodikOperandus}";
                    case "/":
                        return $"{Convert.ToDouble(elsoOperandus) / masodikOperandus}";
                    case "div":
                        return $"{elsoOperandus / masodikOperandus}";
                    case "-":
                        return $"{elsoOperandus - masodikOperandus}";
                    case "+":
                        return $"{elsoOperandus + masodikOperandus}";
                    case "*":
                        return $"{elsoOperandus * masodikOperandus}";
                    default:
                        return "Hibás adat!";
                }
            }
            catch (OverflowException)
            {
                return "Egyéb hiba!";
            }
            catch (DivideByZeroException)
            {
                return "Egyéb hiba!";
            }
        }
    }
}
