namespace FinalProyect.Models;
public static class ProcessPrices
{
    private static readonly Dictionary<ProcessType, int> Prices = new()
    {
        { ProcessType.DerechoEnterramiento, 150 },
        { ProcessType.ExpedicionCertificacion, 200 },
        { ProcessType.RegistroDocumentacion, 100 },
        { ProcessType.DerechoConstruccion, 1500 }
    };

    public static int GetPrice(ProcessType processType, int metros = 0)
    {
        if (processType == ProcessType.ArrendamientoTerreno)
        {
            return metros * 1500;
        }

        return Prices.ContainsKey(processType) ? Prices[processType] : 0;
    }

    public static string GetPriceText(int amount)
    {
        return amount switch
        {
            150 => "Ciento cincuenta pesos dominicanos",
            200 => "Dos ciento pesos dominicanos",
            100 => "Cien pesos dominicanos",
            1500 => "Mil quinientos pesos dominicanos",

            _ => NumeroALetras(amount) + " pesos dominicanos"
        };
    }

    public static string NumeroALetras(int numero)
    {
        if (numero == 0)
            return "cero";

        if (numero < 0)
            return "menos " + NumeroALetras(Math.Abs(numero));

        string letras = "";

        if ((numero / 1000000) > 0)
        {
            letras += NumeroALetras(numero / 1000000) + " millones ";
            numero %= 1000000;
        }

        if ((numero / 1000) > 0)
        {
            letras += NumeroALetras(numero / 1000) + " mil ";
            numero %= 1000;
        }

        if ((numero / 100) > 0)
        {
            letras += Centenas(numero / 100);
            numero %= 100;
        }

        if (numero > 0)
        {
            letras += Unidades(numero);
        }

        return letras.Trim();
    }

    private static string Centenas(int n)
    {
        return n switch
        {
            1 => "cien ",
            2 => "doscientos ",
            3 => "trescientos ",
            4 => "cuatrocientos ",
            5 => "quinientos ",
            6 => "seiscientos ",
            7 => "setecientos ",
            8 => "ochocientos ",
            9 => "novecientos ",
            _ => ""
        };
    }

    private static string Unidades(int n)
    {
        string[] unidades = { "", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
        string[] especiales = { "diez", "once", "doce", "trece", "catorce", "quince",
                                "dieciséis", "diecisiete", "dieciocho", "diecinueve" };
        string[] decenas = { "", "", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };

        if (n < 10)
            return unidades[n];

        if (n < 20)
            return especiales[n - 10];

        if (n < 100)
        {
            int d = n / 10;
            int u = n % 10;

            if (u == 0)
                return decenas[d];

            if (d == 2)
                return "veinti" + unidades[u];

            return decenas[d] + " y " + unidades[u];
        }

        return "";
    }

}
