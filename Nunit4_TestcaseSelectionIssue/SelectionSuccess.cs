using System.Text.Json.Nodes;

namespace Nunit4_TestcaseSelectionIssue
{
    public class SelectionSuccess
    {
        [Test(), TestCaseSource(typeof(SelectionData), nameof(SelectionData.Data))]
        public int TestSuccess(JsonArray jsonArray, int maxSize)
        {
            int count = 0;
            foreach (JsonNode? ja in jsonArray)
            {
                count++;
            }
            Assert.Pass();
            return (int)Math.Ceiling(((double)jsonArray.Count) / maxSize);
        }


        [Test()]
        public void TestSuccess()
        {
            JsonArray jsonArray= new JsonArray((new int[] { 1, 2, 3, 4, 5, 6 }).Select(v => (JsonNode?)v).ToArray());
            int maxSize=4;

            int count = 0;
            foreach (JsonNode? ja in jsonArray)
            {
                count++;
            }
            Assert.That(2, Is.EqualTo((int)Math.Ceiling(((double)jsonArray.Count) / maxSize)));
        }
    }
}