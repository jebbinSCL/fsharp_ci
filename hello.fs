open Message

open System
open System.Net

[<EntryPoint>]
let main _ =
    let listener = new HttpListener()
    listener.Prefixes.Add("http://127.0.0.1:3001/index/")
    listener.Start() |> ignore
    
    let rec loop () = 
            let context = listener.GetContext()
            let request = context.Request;
            let response = context.Response;
            let responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
            let buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 <- (int64) buffer.Length
            let output = response.OutputStream
            output.Write(buffer,0,buffer.Length)
            Console.WriteLine(buffer.Length)
            output.Close() 
            loop()
    loop()

    //listener.Stop() 
    Console.WriteLine(Message.get())
    0
