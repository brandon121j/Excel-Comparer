using Excel_Comparer.Common;

namespace Excel_Comparer.Custom_Controls;

public partial class CompareCriteriaControl : UserControl
{
    public CompareCriteriaControl() => InitializeComponent();

    private void ListBoxAppender()
    {
        ListBoxClearer();
        var compareCriteria = ExcelData.GetCompareCriteria();
        var excel1Columns = ExcelData.Excel1Columns;
        var excel2Columns = ExcelData.Excel2Columns;

        if (compareCriteria.Count > 0)
        {
            excel1Columns?.Where(column => compareCriteria.All(compareItem => column != compareItem.Key || column != compareItem.Value)).ToList().ForEach(i => excel1LB.Items.Add(i));
            excel2Columns?.Where(column => compareCriteria.All(compareItem => column != compareItem.Key || column != compareItem.Value)).ToList().ForEach(i => excel2LB.Items.Add(i));
        }
        else
        {
            excel1Columns?.ForEach(item => excel1LB.Items.Add(item));
            excel2Columns?.ForEach(item => excel2LB.Items.Add(item));
        }

        excel1LB.SelectedItem = excel1LB.Items.Count > 0 ? excel1LB.Items[0] : null;
        excel2LB.SelectedItem = excel2LB.Items.Count > 0 ? excel2LB.Items[0] : null;
    }

    public void ListBoxClearer()
    {
        excel1LB.Items.Clear();
        excel2LB.Items.Clear();
    }

    public void ClearCompareCriteria()
    {
        if (!ExcelData.DataChanged) return;

        comparisonLV.Items.Clear();
        ExcelData.DataChanged = false;
    }

    private void AddCriteria()
    {
        if (excel1LB.SelectedIndex == -1 || excel2LB.SelectedIndex == -1) return;

        var excel1SI = excel1LB?.SelectedItem?.ToString();
        var excel2SI = excel2LB?.SelectedItem?.ToString();

        ExcelData.SetCompareCriteria(excel1SI, excel2SI);

        comparisonLV.Items.Add(new ListViewItem(new[] { excel1SI, excel2SI }));

        excel1LB?.Items.Remove(excel1SI);
        excel2LB?.Items.Remove(excel2SI);

        if (excel1LB.Items.Count > 0 && excel2LB.Items.Count > 0)
            excel1LB.SelectedIndex = excel2LB.SelectedIndex = 0;
    }

    private void AddCriteriaBT_Click(object sender, EventArgs e) => AddCriteria();

    private void RemoveCriteriaBT_Click(object sender, EventArgs e) => RemoveCriteria();

    private void RemoveCriteria()
    {
        if (comparisonLV.SelectedIndices.Count <= 0) return;

        foreach (ListViewItem item in comparisonLV.SelectedItems)
        {
            ExcelData.RemoveCompareCriteria(comparisonLV.Items[item.Index].SubItems[0].Text);

            excel1LB.Items.Add(comparisonLV.Items[item.Index].SubItems[0].Text);
            excel2LB.Items.Add(comparisonLV.Items[item.Index].SubItems[1].Text);
        }

        comparisonLV.Items.RemoveAt(comparisonLV.SelectedIndices[0]);

        excel1LB.SelectedItem = excel1LB.Items.Count > 0 ? excel1LB.Items[0] : null;
        excel2LB.SelectedItem = excel2LB.Items.Count > 0 ? excel2LB.Items[0] : null;

        if (excel1LB.Items.Count > 0 && excel2LB.Items.Count > 0)
            excel1LB.SelectedIndex = excel2LB.SelectedIndex = 0;
    }

    private void CompareCriteriaControl_VisibleChanged(object sender, EventArgs e)
    {
        if (!Visible) return;

        ListBoxAppender();
        ClearCompareCriteria();
    }

    private void Excel2LB_DoubleClick(object sender, EventArgs e)
    {
        var index = excel2LB.IndexFromPoint(Location);

        if (index != ListBox.NoMatches)
            AddCriteria();
    }

    private void Excel1LB_DoubleClick(object sender, EventArgs e)
    {
        var index = excel1LB.IndexFromPoint(Location);

        if (index != ListBox.NoMatches)
            AddCriteria();
    }

    private void ComparisonLV_DoubleClick(object sender, EventArgs e)
    {
        if (comparisonLV.SelectedItems.Count > 0)
            RemoveCriteria();
    }
}