using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XCharts.Runtime;

public class PartyChart : MonoBehaviour
{
    public BarChart chart;

    private List<int> needRemove = new List<int>();
    private List<string> needAdd = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        chart.ClearData();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateAxis();
        UpdateChartData();
    }

    private void UpdateChartData()
    {
        var axis = chart.GetChartComponent<YAxis>();
        var serie = chart.GetSerie(0);

        for (int i = 0; i < axis.data.Count; i++)
        {
            var party = Global.session.parties.Single(x => x.name == axis.data[i]);

            var elem = serie.data.SingleOrDefault(x => x.id == party.name);
            if(elem == null)
            {
                serie.AddXYData(i, party.power, party.name, party.name);
            }
            else
            {
                serie.UpdateYData(i, party.power);
            }
        }
        
    }

    private void UpdateAxis()
    {
        needRemove.Clear();
        needAdd.Clear();

        var axis = chart.GetChartComponent<YAxis>();

        for (int i = 0; i < axis.data.Count; i++)
        {
            if (Global.session.parties.All(x => x.name != axis.data[i]))
            {
                needRemove.Add(i);
            }
        }

        foreach (var party in Global.session.parties)
        {
            if (!axis.data.Contains(party.name))
            {
                needAdd.Add(party.name);
            }
        }

        foreach (var elem in needRemove.OrderByDescending(x => x))
        {
            axis.RemoveData(elem);
        }

        foreach (var elem in needAdd)
        {
            axis.AddData(elem);
        }
    }
}
