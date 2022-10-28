﻿using System.Text.Json;

namespace EzjobApi.Error
{
  public class HttpResponseException : Exception
  {

    public HttpResponseException(string message = "Server Error") : base(message)
    {
      StatusCode = 500;
    }
    public HttpResponseException(string message = "Server Error", int statusCode = 500) : base(message)
    {
      StatusCode = statusCode;
    }

    public int StatusCode { get; set; }
    public override string ToString() => JsonSerializer.Serialize(new
    {
      message = Message,
      statusCode = StatusCode
    });

  }
}
