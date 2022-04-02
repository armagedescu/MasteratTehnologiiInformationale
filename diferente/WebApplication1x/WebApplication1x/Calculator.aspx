<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="WebApplication1x.CalculatorWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="calculator.js"></script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="Calculator">
        <div>
            <asp:TextBox ID="Expression" runat="server" Width="457px"></asp:TextBox>
        </div>
        <asp:Button ID="Calculator" runat="server" OnClick="Button1_Click" Text="Calculeaza" /><asp:Label ID="Result" runat="server"></asp:Label>
        <br />
        <table cellpading="0" cellspacing="0" border="0">
            <tr>
               <td><button onclick="javascript:pressPl()">(</button></td>
               <td><button onclick="javascript:pressPr()">)</button></td>
               <td><button onclick="javascript:pressBs()">bs</button></td>
               <td><button onclick="javascript:pressDivide()">/</button></td>
            </tr>
            <tr>
               <td><button onclick="javascript:press7()">7</button></td>
               <td><button onclick="javascript:press8()">8</button></td>
               <td><button onclick="javascript:press9()">9</button></td>
               <td><button onclick="javascript:pressMultiply()">*</button></td>
            </tr>
            <tr>
               <td><button onclick="javascript:press4()">4</button></td>
               <td><button onclick="javascript:press5()">5</button></td>
               <td><button onclick="javascript:press6()">6</button></td>
               <td><button onclick="javascript:pressMinus()">-</button></td>
            </tr>
            <tr>
               <td><button onclick="javascript:press1()">1</button></td>
               <td><button onclick="javascript:press2()">2</button></td>
               <td><button onclick="javascript:press3()">3</button></td>
               <td><button onclick="javascript:pressPlus()">+</button></td>
            </tr>
            <tr>
               <td><button onclick="javascript:pressClear()">cls</button></td>
               <td><button onclick="javascript:press0()" >0</button></td>
               <td><button onclick="javascript:pressPt()">.</button></td>
               <td><button onclick="javascript:pressEnter()">=</button></td>
            </tr>
        </table>
    </form>
</body>
</html>
