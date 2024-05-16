using System;
using System.Text;
namespace AppWorkshop
{
	public static class PhonewordTranslator
	{

		//converte string pra numero
		public static string toNumber (string raw)
		{

			//verificar se string é nula
			if (String.IsNullOrWhiteSpace(raw))
				return null;

			//muda string pra maiuscula
			raw = raw.ToUpperInvariant();

			//pelo que li new StringBuilder é pra criar string de forma "eficiente"
			var newNumber = new StringBuilder();

			//para cada caractere da string
			foreach(var c in raw)
			{
				//se a string tiver um ifen ou algum numero, ja add ao novo numero
				if ("-0123456789".Contains(c))
					newNumber.Append(c);
				else
				{
					//caso contrario vai traduzir um caracter para um numero
					var result = TranslateToNumber(c);
					if (result != null)
						newNumber.Append(result);
					else
						return null; //caso tiver caractere inválido
				}
			}
			return newNumber.ToString(); //retorna numero traduzido
		}

        // verifica se uma string contém um caractere específico
        static bool Contains(this string keyString, char c)
		{
			return keyString.IndexOf(c) >= 0;
		}

        // array de strings representando os grupos de letras e seus números correspondentes
        static readonly string[] digits =
        {
            "AB",   // 0
            "CD",   // 1
            "EF",   // 2
            "GH",   // 3
            "IJ",   // 4
            "KL",   // 5
            "MN",   // 6
            "OPQ",  // 7
            "RST",  // 8
            "UVW",  // 9
            "XYZ"   // -
        };

        //traduz uma letra para seu número correspondente
        static string TranslateToNumber(char c)
        {
            // for sobre os grupos de letras
            for (int i = 0; i < digits.Length; i++)
            {
                // ver se o caractere está no grupo atual
                if (digits[i].Contains(c))
                {
                    // se o grupo for "XYZ", retorna o hífen
                    if (i == digits.Length - 1)
                        return "-";
                    else
                        return i.ToString(); // retorna o número correspondente (0 ate 9)
                }
            }
            return null; // retorna null se o caractere não for encontrado
        }
    }
}













