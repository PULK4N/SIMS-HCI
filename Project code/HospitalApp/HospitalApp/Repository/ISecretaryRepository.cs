﻿// File:    ISecretaryRepository.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:36:32 AM
// Purpose: Definition of Interface ISecretaryRepository

using System;
using System.Collections.Generic;

public interface ISecretaryRepository
{
    List<Secretary> GetAllSecretaries();

    Secretary GetById(long secretaryId);

    bool DeleteByID(long secretaryId);

    Secretary UpdateSecretary(Secretary secretary);

    Secretary SaveSecretary(Secretary secretary);

    Secretary GetSecretaryByEmail(string email);
}