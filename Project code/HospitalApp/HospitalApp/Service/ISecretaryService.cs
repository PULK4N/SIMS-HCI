// File:    SecretaryService.cs
// Author:  Lenovo_NB
// Created: cetvrtak, 28. maj 2020. 14:08:45
// Purpose: Definition of Class SecretaryService

using System.Collections.Generic;

public interface ISecretaryService
{
    List<Secretary> GetAllSecretaries();

    Secretary GetById(long secretaryId);

    bool DeleteByID(long secretaryId);

    Secretary UpdateSecretary(Secretary secretary);

    Secretary SaveSecretary(Secretary secretary);

    Secretary GetSecretaryByEmail(string email);
}