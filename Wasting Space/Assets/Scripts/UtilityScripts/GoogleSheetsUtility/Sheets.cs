using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
//using UnityEngine;

public class Sheets
{
    private static string[] scopes = { SheetsService.Scope.Spreadsheets }; // Change this if you're accessing Drive or Docs
    private static string applicationName = "WastingSpace Leaderboard";
    private static string spreadsheetId = "1qspFp4iMcoRntV_UNfm5Pt8cm4xXYRoK9UhJbB74ebw";
    private static SheetsService service;
    private static string path = Environment.CurrentDirectory + "/Assets/Resources/Credentials";


    public static void ConnectToGoogle()
    {
        GoogleCredential credential;

        //Debug.Log(Environment.CurrentDirectory);
        // Put your credentials json file in the root of the solution and make sure copy to output dir property is set to always copy 
        using (var stream = new FileStream(Path.Combine(path + "/credentials.json"),
            FileMode.Open, FileAccess.Read))
        {
            credential = GoogleCredential.FromStream(stream).CreateScoped(scopes);
        }

        // Create Google Sheets API service.
        service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = applicationName
        });
    }
    public static bool AddScoreEntry(int score, string name)
    {
        try
        {
            string range = "Scores!A2:B";
            var dataValueRange = new ValueRange();
            dataValueRange.Range = range;
            var oblist = new List<object>() {name,score };
            dataValueRange.Values = new List<IList<object>> { oblist };

            SpreadsheetsResource.ValuesResource.AppendRequest update = service.Spreadsheets.Values.Append(dataValueRange, spreadsheetId, range);
            update.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.RAW;
            AppendValuesResponse result2 = update.Execute();

            Console.WriteLine("done!");
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public static bool AddFeebackEntry(string name, int rating, string feedback)
    {
        try
        {
            string range = "Feedback!A2:C";
            var dataValueRange = new ValueRange();
            dataValueRange.Range = range;
            var oblist = new List<object>() { name, rating, feedback };
            dataValueRange.Values = new List<IList<object>> { oblist };

            SpreadsheetsResource.ValuesResource.AppendRequest update = service.Spreadsheets.Values.Append(dataValueRange, spreadsheetId, range);
            update.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.RAW;
            AppendValuesResponse result2 = update.Execute();

            Console.WriteLine("done!");
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public static bool SortRequest()
    {
        BatchUpdateSpreadsheetRequest busReq = new BatchUpdateSpreadsheetRequest();
        SortSpec ss = new SortSpec();
        // ordering ASCENDING or DESCENDING
        ss.DimensionIndex = 1;
        ss.SortOrder = "DESCENDING";
        // the column number starting from 0
        SortRangeRequest srr = new SortRangeRequest();
        IList<SortSpec> sortSpecs = new List<SortSpec>();
        sortSpecs.Add(ss);
        srr.SortSpecs = sortSpecs;
        Request req = new Request();
        req.SortRange = srr;
        IList<Request> reqs = new List<Request>();
        reqs.Add(req);
        busReq.Requests = reqs;
        //service is a instance of com.google.api.services.sheets.v4.Sheets
        SpreadsheetsResource.BatchUpdateRequest sortReq = service.Spreadsheets.BatchUpdate(busReq, spreadsheetId);

        try
        {
            sortReq.Execute();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public static List<ScoreboardObject> GetScores()
    {
        string range = "Scores!A2:B";
        SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);
        ValueRange response = request.Execute();
        IList<IList<Object>> values = response.Values;
        if (values != null && values.Count > 0)
        {
            List<ScoreboardObject> scoreList = new List<ScoreboardObject>();
            for (int i = 0;i<5;i++)
            {
                scoreList.Add(new ScoreboardObject() { score = values[i][1], name = values[i][0]});
            }
            return scoreList;
        }
        return null;
    }
}

public class ScoreboardObject
{
    public object score;
    public object name;
}

