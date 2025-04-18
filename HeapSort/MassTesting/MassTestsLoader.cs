using System;
using System.Collections.Generic;
using System.Xml;

namespace HeapSort.MassTesting;

public static class MassTestsLoader
{
    public static List<IMassTest> LoadFromXml(string filePath)
    {
        var massTests = new List<IMassTest>();
        var doc = new XmlDocument();
        doc.Load(filePath);
        
        var experiments = doc.DocumentElement?.SelectNodes("experiment");
        if (experiments is null) return massTests;

        foreach (XmlNode experiment in experiments)
        {
            var massTestName = experiment.Attributes?["name"]?.Value;
            var nodes = experiment.SelectNodes("node");
            if (nodes is null) continue;
            
            foreach (XmlNode node in nodes)
            {
                switch (massTestName)
                {
                    case "Arithmetic Progression":
                        massTests.Add(ProcessArithmeticProgressionTest(node));
                        break;
                    case "Geometric Progression":
                        massTests.Add(ProcessGeometricProgressionTest(node));
                        break;
                }
            }
        }
        
        return massTests;
    }

    private static ArithmeticProgressionMassTest ProcessArithmeticProgressionTest(XmlNode node)
    {
        return new ArithmeticProgressionMassTest(
            node.Attributes!["name"]!.Value,
            int.Parse(node.Attributes["startLength"]!.Value),
            int.Parse(node.Attributes["maxLength"]!.Value),
            byte.Parse(node.Attributes["repeat"]!.Value),
            int.Parse(node.Attributes["diff"]!.Value)
            );
    }
    
    private static GeometricProgressionMassTest ProcessGeometricProgressionTest(XmlNode node)
    {
        return new GeometricProgressionMassTest(
            node.Attributes!["name"]!.Value,
            int.Parse(node.Attributes["startLength"]!.Value),
            int.Parse(node.Attributes["maxLength"]!.Value),
            byte.Parse(node.Attributes["repeat"]!.Value),
            byte.Parse(node.Attributes["znamen"]!.Value)
        );
    }
}