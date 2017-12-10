module TextbookCode

open System.Drawing
open DataTypes

let rc = {
    Left = 10.0f;
    Top = 10.0f;
    Width = 100.0f;
    Height = 200.0f;
    }
    
let rc2 = {rc with Left = rc.Left + 100.0f}

let it1 = {Left = 0.0f; Top = 0.0f; Width = 100.0f; Height = 100.0f}

let it2 = Rect.deflate(it1,20.0f,10.0f)

//////////////////////////////////////////












