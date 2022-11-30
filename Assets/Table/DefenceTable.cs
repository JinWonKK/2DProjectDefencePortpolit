using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class DefenceTable : ScriptableObject
{
	public List<BUnitClass> BUnit;
	public List<RUnitClass> RUnit;
	public List<TipClass> tipData;
	public List<StageClass> stageData;
}
