using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ClientInfo
{
    public string id;
    public string nom;
    public string prenom;
    public string dateNaiss;
    public string lieu;
    public string nationalite;
    public string profession;
    public string domicile;
    public string email;
    public string tel;
    public string venantDe;
    public string allantA;
    public string entreLe;
    public string dateDep;
    public string PassOrCIN;
    public string num;
    public string delivreLe;
    public string a;
    public string par;
    public string numChambre;

public ClientInfo()
{

}

public ClientInfo(string nom, string prenom, string dateNaiss, string lieu, string nationalite, string profession, string domicile, string email, string tel, string venantDe, string allantA, string entreLe, string dateDep, string PassOrCIN, string num, string delivreLe, string a, string par, string numChambre)
{
        this.nom = nom;
        this.prenom = prenom;
        this.dateNaiss = dateNaiss;
        this.lieu = lieu;
        this.nationalite = nationalite;
        this.profession = profession;
        this.domicile = domicile;
        this.email = email;
        this.tel = tel;
        this.venantDe = venantDe;
        this.allantA = allantA;
        this.entreLe = entreLe;
        this.dateDep = dateDep;
        this.PassOrCIN = PassOrCIN;
        this.num = num;
        this.delivreLe = delivreLe;
        this.a = a;
        this.par = par;
        this.numChambre = numChambre;
    }

}
