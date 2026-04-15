

//File để hứng dữ liệu từ server về

using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class ResponseType<T> {

    public int statusCode {get;set;}
    public string message {get;set;}
    public DateTime dateTime {get;set;}

    public T content {get;set;}


    // void main ()
    // {
    //     var item = new ResponseType<ProductHeaderValue[]>();
    // }

}

