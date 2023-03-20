using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital;

public class AppFunc
{
    

    // -------------------------------------------------------------------- IS PALINDROME FUNCTION -------------------------------------------------///////////
    // This function is case sensitive
    // We could change that by getting string into uppercase or lowercase 
    public bool isPalindrome(string txt)
    {
        // Text should not be null nor empty 
        if (txt == null || txt.Length == 0) return false;

        // For even length
        if (txt.Length % 2 == 0)
        {
            return txt.Substring(0, txt.Length / 2) == ExternalFunctions.ReverseString(txt.Substring(txt.Length / 2));
        }
        // For odd length
        else
        {
            return txt.Substring(0, (txt.Length - 1) / 2) == ExternalFunctions.ReverseString(txt.Substring((txt.Length + 1) / 2));
        }

    }

    // -------------------------------------------------------------------- MIN SPLIT FUNCTION -----------------------------------------------------///////////
    // Takes amount in cents 
    public int minSplit(int amountCents)
    {
        int coinRet = 0;
        int ReminderAmt = amountCents;
        int[] coinArray = { 50, 20, 10, 5, 1 };
        int i = 0;

        while (true)
        {
            coinRet += (ReminderAmt / coinArray[i]);
            ReminderAmt = (amountCents % coinArray[i]);
            i++;
            if (i == coinArray.Length)
                break;
        }

        return coinRet;
    }

    // ------------------------------------------------------------- DOES NOT CONTAIN FUNCTION -----------------------------------------------------///////////

    public int notContains(int[] intArray)
    {
        int i = 0;

        while (true)
        {
            i++;
            var a = from x in intArray
                    where x == i
                    select (int)x;
            if (a.Count() == 0)
                break;
        }
        return i;
    }

    // ------------------------------------------------------------- IS PROPERLY FUNCTION -----------------------------------------------------------///////////

    public bool isProperly(string str)
    {
        string strOp = str;
        while (true)
        {
            int openFirstPosition, closeFirstPosition;
            openFirstPosition = Strings.InStr(strOp, "(");
            closeFirstPosition = Strings.InStr(strOp, ")");
            if (openFirstPosition != 0)
            {
                if (closeFirstPosition > openFirstPosition)
                {
                    strOp = ExternalFunctions.RemoveCharacterFirstOccurrence(strOp, "(");
                    strOp = ExternalFunctions.RemoveCharacterFirstOccurrence(strOp, ")");
                }
                else
                    return false;
            }
            else
            {
                if (closeFirstPosition != 0)
                    return false;
                else
                    return true;
            }
        }
    }

    // ------------------------------------------------------------- COUNT VARIANTS -----------------------------------------------------------///////////
    // Count of varieties for this task would be the n-th fibonacci number ( where n is quantity of stairs ) 
    public int CountVariants(int stairCount)
    {
        if (stairCount <= 1)
            return stairCount;
        return CountVariants(stairCount - 1) + CountVariants(stairCount - 2);
    }

}

public static class ExternalFunctions
{
    public static string ReverseString(string st)
    {
        char[] charArray = st.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public static string RemoveCharacterFirstOccurrence(string str, string characterToRemvoe)
    {
        return str.Substring(0, Strings.InStr(str, characterToRemvoe) - 1) + str.Substring(Strings.InStr(str, characterToRemvoe));
    }


}

    // ------------------------------------------------ TASK N8 - CREATING FILES USING API CALL ------------------------------------------------------------

public class MakeApiCall
{
    public static string Url = $"https://restcountries.com/v3.1/all";
    public void GenerateCountryDataFiles()
    {
        string dataRaw;
        WebRequest webRequest = WebRequest.Create(Url);

        webRequest.Method = "GET";

        HttpWebResponse responseObject = (HttpWebResponse)webRequest.GetResponse();
        // Gets data as a raw string 
        using (Stream stream = responseObject.GetResponseStream())
        {
            StreamReader sr = new StreamReader(stream);
            dataRaw = sr.ReadToEnd();
            sr.Close();
        }

        var JTokenArray = JsonConvert.DeserializeObject<JToken>(dataRaw);
        // Creates files into this location ( folder )
        string location = @"C:\Users\Tommy\source\repos\SweeftAccelerationConsole\TextFiles\";

        foreach (var o in JTokenArray)
        {
            string nameContainerString = o.Children().FirstOrDefault().Children().FirstOrDefault().Children().FirstOrDefault().ToString();

            string JTokenBody = o.ToString();

            string name = nameContainerString.Substring(11, nameContainerString.Length - 12);

            using (FileStream fs = File.Create(location + name + ".txt"))
            {
                byte[] textBytes = new UTF8Encoding(true).GetBytes(JTokenBody);
                fs.Write(textBytes, 0, textBytes.Length);

            }
        }
    }
}



