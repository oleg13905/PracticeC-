using System;
using System.Text;

namespace Task3
{

    public class Graph
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public double[] Data { get; set; }
        public string[] Labels { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
        return $@"
{Title} ({Type}) 
Данные: [{string.Join(", ", Data)}]
Метки: [{string.Join(", ", Labels)}]
Цвет: {Color}";
        }
    }

    public interface IGraphBuilder
    {
        void SetTitle(string title);
        void SetData(double[] data);
        void SetLabels(string[] labels);
        void SetColor(string color);
        Graph GetGraph();
    }

    public class LineGraphBuilder : IGraphBuilder
    {
        private Graph graph = new Graph { Type = "Линейный график" };

        public void SetTitle(string title) => graph.Title = title;
        public void SetData(double[] data) => graph.Data = data;
        public void SetLabels(string[] labels) => graph.Labels = labels;
        public void SetColor(string color) => graph.Color = color ?? "синий";
        public Graph GetGraph() => graph;
    }

    public class BarGraphBuilder : IGraphBuilder
    {
        private Graph graph = new Graph { Type = "Столбчатый график" };

        public void SetTitle(string title) => graph.Title = title;
        public void SetData(double[] data) => graph.Data = data;
        public void SetLabels(string[] labels) => graph.Labels = labels;
        public void SetColor(string color) => graph.Color = color ?? "зеленый";
        public Graph GetGraph() => graph;
    }

    public class PieChartBuilder : IGraphBuilder
    {
        private Graph graph = new Graph { Type = "Круговая диаграмма" };

        public void SetTitle(string title) => graph.Title = title;
        public void SetData(double[] data) => graph.Data = data;
        public void SetLabels(string[] labels) => graph.Labels = labels;
        public void SetColor(string color) => graph.Color = color ?? "красный";
        public Graph GetGraph() => graph;
    }

    public class GraphDirector
    {
        private IGraphBuilder builder;

        public GraphDirector(IGraphBuilder builder) => this.builder = builder;

        public void ConstructSalesGraph()
        {
            double[] salesData = { 100, 150, 200, 120, 180 };
            string[] months = { "Янв", "Фев", "Мар", "Апр", "Май" };

            builder.SetTitle("Продажи за 2026");
            builder.SetData(salesData);
            builder.SetLabels(months);
            builder.SetColor("оранжевый");
        }
    }

    class Program
    {
        static void Main()
        {
            LineGraphBuilder lineBuilder = new LineGraphBuilder();
            lineBuilder.SetTitle("Температура");
            lineBuilder.SetData(new double[] { 20, 22, 25, 23, 27 });
            lineBuilder.SetLabels(new string[] { "Пн", "Вт", "Ср", "Чт", "Пт" });
            Console.WriteLine(lineBuilder.GetGraph());

            BarGraphBuilder barBuilder = new BarGraphBuilder();
            GraphDirector director = new GraphDirector(barBuilder);
            director.ConstructSalesGraph();
            Console.WriteLine(barBuilder.GetGraph());

            PieChartBuilder pieBuilder = new PieChartBuilder();
            pieBuilder.SetTitle("Доли рынка");
            pieBuilder.SetData(new double[] { 40, 30, 20, 10 });
            pieBuilder.SetLabels(new string[] { "A", "B", "C", "D" });
            pieBuilder.SetColor("фиолетовый");
            Console.WriteLine(pieBuilder.GetGraph());
        }
    }
}