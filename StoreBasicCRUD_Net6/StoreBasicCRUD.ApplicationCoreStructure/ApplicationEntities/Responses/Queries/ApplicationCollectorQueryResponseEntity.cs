﻿using StoreBasicCRUD.SharedCoreStructure.SharedResponseEntities;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries
{
    public class ApplicationCollectorQueryResponseEntity<T> : GenericDataResponseEntity<T>
    {
        public int StatusResponse { get; set; }
        public string? Information { get; set; }
        public object? ValidationErrors { get; set; }
    }
}
