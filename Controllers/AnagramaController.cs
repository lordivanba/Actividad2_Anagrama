using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actividad2_Anagrama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnagramaController : ControllerBase
    {
        [HttpGet("{palabra1},{palabra2}")]
        public string getAnagrama(string Palabra1, string Palabra2) 
        {
            string resultado;
            string palabraSugerida;
            char[] word1 = Palabra1.ToLower().ToCharArray();
            char[] word2 = Palabra2.ToLower().ToCharArray();
            Array.Sort(word1);
            Array.Sort(word2);
            string result1 = new string(word1);
            string result2 = new string(word2);

            if (result1 == result2)
            {
                resultado = $"Las palabras: |{Palabra1}| y |{Palabra2}| son anagramas.";
            }
            else
            {
                resultado = $"Las palabras: |{Palabra1}| y |{Palabra2}| no son anagramas.";
                Random randomNumber = new Random();
                int n = randomNumber.Next(1,5);
                switch (n)
                {
                    case 1:
                        palabraSugerida = "Desamparador, desparramado";
                        break;
                    case 2:
                        palabraSugerida = "Conservadora, conversadora";
                        break;
                    case 3:
                        palabraSugerida = "Frase, fresa";
                        break;
                    case 4:
                        palabraSugerida = "Amor, roma";
                        break;
                    default:
                        palabraSugerida = "Acuerdo, ecuador";
                        break;
                }
                resultado = resultado + $"\n Palabras sugeridas: {palabraSugerida}";
            }
            return $"{resultado}";
        }
    }
}
