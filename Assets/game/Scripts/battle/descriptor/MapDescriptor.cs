using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace bc.battle
{
    public class MapDescriptor
    {
        const string LEVEL_PATH = "maps/";

        public RowDescriptor[] rows;

        public class RowDescriptor
        {
            public CellDescriptor[] cells;
        }

        public class CellDescriptor
        {
            public int x;
            public int y;
            public CellType type;
        }

        public MapDescriptor(string name) {
            TextAsset textAss = Resources.Load<TextAsset>(LEVEL_PATH + name);
            ParceMap(textAss);
        }

        public MapDescriptor(TextAsset textAss) {
            ParceMap(textAss);
        }

        private void ParceMap(TextAsset textAss)
        {
            string text = textAss.ToString();
            string[] lines = text.Split('\n');
            string[][] tokens = new string[lines.Length][];
            for (int li = 0; li < lines.Length; li++)
            {
                string[] lineTokens = lines[li].Split(',');
                for (int i = 0; i < lineTokens.Length; i++)
                {
                    lineTokens[i] = lineTokens[i].Trim();
                }
                tokens[li] = lineTokens;
            }
            int rowCount = 0;
            int maxColumnCount = 0;
            List<string[]> gridTmp = new List<string[]>();
            for (int li = 0; li < lines.Length; li++) {
                string[] lineTokens = tokens[li];
                switch (lineTokens[0])
                {
                    case "type":
                        Debug.Log(lineTokens[0]);
                        break;
                    default:
                        rowCount++;
                        maxColumnCount = Mathf.Max(maxColumnCount, lineTokens.Length );
                        gridTmp.Add(lineTokens);
                        break;
                }
            }
            rows = new RowDescriptor[rowCount];
            for (int i = 0; i < rowCount; i++) {
                rows[i] = new RowDescriptor();
                rows[i].cells =  new CellDescriptor[maxColumnCount];
                for (int j = 0; j < maxColumnCount; j++) {
                    CellType type = CellType.EMPTY;
                    if (gridTmp[i].Length > j) {
                        string attr = gridTmp[i][j];
                        foreach (char a in attr)
                        {
                            if (Enum.IsDefined(typeof(CellType), (int)a))
                            {
                                type = (CellType)(int)a;
                            }
                        }
                    }

                    rows[i].cells[j] = new CellDescriptor() { type = type , x = j, y = i};
                }
            }            
        }
    }
}
