﻿namespace AngularApp1.Server.Infraestructure.Dto
{
    public class ResponseDTO<T>
    {
            public bool status { get; set; }
            public string? msg { get; set; }
            public T? value { get; set; }
        
    }
}
