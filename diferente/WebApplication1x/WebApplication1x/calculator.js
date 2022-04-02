function pressBs()
{
    let ndv = document.getElementById("Expression").value;
    if (ndv.length <= 0) return;
    document.getElementById("Expression").value = ndv.substr(0, ndv.length - 1);
    void (0);
}
function pressClear() {
    document.getElementById("Expression").value = "";
    void (0);
}
function pressPt() { document.getElementById("Expression").value += "("; void(0);}
function pressPl() { document.getElementById("Expression").value += "("; void(0);}
function pressPr() { document.getElementById("Expression").value += ")"; void(0);}
function press0() { document.getElementById("Expression").value += "0"; void(0);}
function press1() { document.getElementById("Expression").value += "1"; void(0);}
function press2() { document.getElementById("Expression").value += "2"; void(0);}
function press3() { document.getElementById("Expression").value += "3"; void(0);}
function press4() { document.getElementById("Expression").value += "4"; void(0);}
function press5() { document.getElementById("Expression").value += "5"; void(0);}
function press6() { document.getElementById("Expression").value += "6"; void(0);}
function press7() { document.getElementById("Expression").value += "7"; void(0);}
function press8() { document.getElementById("Expression").value += "8"; void(0);}
function press9() { document.getElementById("Expression").value += "9"; void (0);}
function pressPlus() { document.getElementById("Expression").value += "+"; void (0);}
function pressMinus() { document.getElementById("Expression").value += "-"; void (0);}
function pressMultiply() { document.getElementById("Expression").value += "*"; void (0);}
function pressDivide() { document.getElementById("Expression").value += "/"; void (0);}
