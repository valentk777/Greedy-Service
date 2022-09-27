namespace Greedy.Domain.Graphs
{
    public class GraphService :IGraphService
    {
        private readonly IGraphManager _graphManager;

        public GraphService(IGraphManager graphManager)
        {
            _graphManager = graphManager;
        }
    }
}