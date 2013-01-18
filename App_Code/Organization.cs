﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class Organization : DatabaseObject
{
    public int Id { set; get; }
    public string Name { set; get; }
    public string Website { set; get; }
    public string Description { set; get; }
    public int UserId { set; get; }

    private static Organization instantiate(DataSet ds)
    {
        Organization o = new Organization();

        o.Id = Convert.ToInt16(ds.Tables[0].Rows[0]["id"]);
        o.Name = ds.Tables[0].Rows[0]["name"].ToString();
        o.Website = ds.Tables[0].Rows[0]["website"].ToString();
        o.UserId = Convert.ToInt16(ds.Tables[0].Rows[0]["user_id"]);
        o.Description = ds.Tables[0].Rows[0]["description"].ToString();

        return o;
    }

    public void insert()
    {
        insert(String.Format("INSERT INTO organization VALUES ('{0}', '{1}', '{2}', '{3}')", UserId, Name, Description, Website));
    }

    public void update()
    {
        update(String.Format("UPDATE organization SET user_id = '{1}', name = '{2}', description = '{3}', website = '{4}' WHERE id = '{0}'", Id, Name, Description, Website));
    }

    public void delete()
    {
        update(String.Format("DELETE FROM organization WHERE id = '{0}'", Id));
    }

    public static DataSet loadAll()
    {
        return query("SELECT * FROM organization");
    }

    public static DataSet loadById(int id)
    {
        DataSet ds = query(String.Format("SELECT * FROM users WHERE id = '{0}'", id));
        instantiate(ds);
        return ds;
    }

    public static int countAll()
    {
        return Convert.ToInt16(query("SELECT COUNT(*) FROM organization").Tables[0].Rows[0][0]);
    }
}