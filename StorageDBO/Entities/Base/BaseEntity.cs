﻿namespace StorageDBO.Entities.Base;

public abstract class BaseEntity<T> where T : struct
{
    public T Id { get; set; } = default;
}
