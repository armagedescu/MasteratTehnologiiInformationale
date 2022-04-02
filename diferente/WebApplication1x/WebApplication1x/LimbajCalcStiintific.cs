using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Globalization;

namespace WebApplication1x
{
    public class LimbajCalcStiintific
    {
		enum OperatorBinarMat { mul, div, mod, add, sub, undef }
		//Nu este implementat
		bool Comentariu(ref string s, ref int pos)
		{
			if (pos >= s.Length) return false;
			return false;
		}
		bool Spatii(ref string s, ref int pos)
		{
			int savePos = pos;
			while (pos < s.Length && char.IsWhiteSpace(s[pos])) pos++;
			if (savePos == pos) return false;
			return true;
		}
		bool Ignorabil(ref string s, ref int pos)
		{
			while (Spatii(ref s, ref pos) || Comentariu(ref s, ref pos)) ;
			return true;
		}
		bool Cifra(ref string s, ref int pos)
		{
			if (pos >= s.Length) return false;
			switch (s[pos] - '0')
			{
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
					pos++;
					return true;
			}
			return false;
		}
		bool ConstantaNumerica(ref string s, ref int pos, ref bool eroare, ref Expression ex)
		{
			int start = pos;
			if (pos >= s.Length) eroare = true;
			if (eroare) return false;
			bool res = false;
			while (pos < s.Length && Cifra(ref s, ref pos)) res = true;
			if (pos < s.Length && s[pos] == '.')
			{
				pos++;
				while (pos < s.Length && Cifra(ref s, ref pos)) res = true;
			}
			if (res)
				ex = Expression.Constant(double.Parse(s.Substring(start, pos - start), CultureInfo.InvariantCulture));
			return res;
		}

		bool OperatorBinar(ref string s, ref int pos, ref OperatorBinarMat op)
		{
			op = OperatorBinarMat.undef;
			if (pos >= s.Length) return false;
			switch (s[pos])
			{
				case '*': pos++; op = OperatorBinarMat.mul; return true;
				case '/': pos++; op = OperatorBinarMat.div; return true;
				case ':': pos++; op = OperatorBinarMat.mod; return true;
				case '+': pos++; op = OperatorBinarMat.add; return true;
				case '-': pos++; op = OperatorBinarMat.sub; return true;
			}
			return false;
		}

		bool Paranteze(ref string s, ref int pos, ref bool eroare, ref Expression ex)
		{
			if (pos >= s.Length) eroare = true;
			if (eroare) return false;
			if (s[pos] == '(')
			{
				pos++;
				Expression subex = null;
				if (!Expresie(ref s, ref pos, ref eroare, ref subex))
					if (eroare) return false;
				if (pos >= s.Length) { eroare = true; return false; }
				if (s[pos] == ')')
				{
					ex = subex;
					pos++;
					return true;
				}
				eroare = true;
			}
			return false;
		}

		bool ExpresieUnara(ref string s, ref int pos, ref bool eroare, ref Expression ex)
		{
			if (pos >= s.Length) eroare = true;
			if (eroare) return false;
			bool neg = false;
			if (s[pos] == '-') neg = true;
			if (s[pos] == '-' || s[pos] == '+') pos++;
			Ignorabil(ref s, ref pos);
			if (pos >= s.Length) eroare = true;
			if (eroare) return false;

			Expression unexp = null;
			if (ConstantaNumerica(ref s, ref pos, ref eroare, ref unexp) || Paranteze(ref s, ref pos, ref eroare, ref unexp))
			{
				ex = neg ? Expression.Negate(unexp) : unexp;
				return true;
			}
			eroare = true;
			return false;
		}
		struct Agregator
		{
			public Expression stanga, dreapta;
			public OperatorBinarMat o;
			public void Pgregare(OperatorBinarMat o, Expression exd)
			{
				//Daca in dreapta e null inseamna ca e prima operatie din expresie
				//In acest caz agregam in ramura stanga a arborelui
				switch (o)
				{
					case OperatorBinarMat.mul:
						if (dreapta == null) stanga = Expression.Multiply(stanga, exd);
						else dreapta = Expression.Multiply(dreapta, exd);
						break;
					case OperatorBinarMat.div:
						if (dreapta == null) stanga = Expression.Divide(stanga, exd);
						else dreapta = Expression.Divide(dreapta, exd);
						break;
					default:
						throw new Exception("Agregarea necesita operator agregabil: *:/");
				}
			}
			public void Prepara(OperatorBinarMat op, Expression dr)
			{
				switch (o)
				{
					case OperatorBinarMat.add: stanga = Expression.Add(stanga, dreapta); break;
					case OperatorBinarMat.sub: stanga = Expression.Subtract(stanga, dreapta); break;
					default:
						if (op != OperatorBinarMat.add && op != OperatorBinarMat.sub)
							throw new Exception("Prepararea accepta numai expresii neagregate: +-");
						break;
				}
				dreapta = dr;
				o = op;
			}
			public Expression Construieste()
			{
				if (dreapta == null) return stanga;
				switch (o)
				{
					case OperatorBinarMat.add: return Expression.Add(stanga, dreapta);
					case OperatorBinarMat.sub: return Expression.Subtract(stanga, dreapta);
					default: throw new Exception("Expresiile incompleta");
				}
			}
		}
		// ... +xxx ...
		bool ExpresieDreapta(ref string s, ref int pos, ref bool eroare, ref Expression ex)
		{
			Agregator ag = new Agregator() { stanga = ex, dreapta = null, o = OperatorBinarMat.undef };
			for (; pos < s.Length;)
			{
				OperatorBinarMat op = OperatorBinarMat.undef;
				Ignorabil(ref s, ref pos);
				if (!OperatorBinar(ref s, ref pos, ref op)) break;

				Ignorabil(ref s, ref pos);
				if (pos >= s.Length) { eroare = true; return false; }

				Expression expDreapta = null;
				if (ExpresieUnara(ref s, ref pos, ref eroare, ref expDreapta)) eroare = false;
				else { eroare = true; return false; }

				switch (op)
				{
					//plasare in ramura dreapta a arborelui
					case OperatorBinarMat.mul: case OperatorBinarMat.div: ag.Pgregare(op, expDreapta); break;
					//preparare pentru plasarea in ramura stanga ori in nodul arborelui
					case OperatorBinarMat.add: case OperatorBinarMat.sub: ag.Prepara(op, expDreapta); break;
				}

				Ignorabil(ref s, ref pos);
			}
			ex = ag.Construieste();
			return true;
		}
		public bool Expresie(ref string s, ref int pos, ref bool eroare, ref Expression ex)
		{
			Ignorabil(ref s, ref pos);
			if (pos >= s.Length) eroare = true;
			if (eroare) return false;
			Expression expStanga = null;
			if (ExpresieUnara(ref s, ref pos, ref eroare, ref expStanga))
			{
				Ignorabil(ref s, ref pos);
				eroare = false;
				if (pos == s.Length) { ex = expStanga; return true; }
			}
			else return false; //nu este expresie unara, nu poate face parte din nici o expresie cu operator binar

			//operatorul binar tot ce e in partea dreapta de el
			if (ExpresieDreapta(ref s, ref pos, ref eroare, ref expStanga))
			{
				ex = expStanga;
				return true;
			}

			return false;
		}
		public Expression Compileaza(ref string expresie)
		{
			int pos = 0;
			bool eroare = false;
			Expression exp = null;
			bool ret = Expresie(ref expresie, ref pos, ref eroare, ref exp);
			if (pos != expresie.Length) ret = false; //nu a ajuns ori a trecut peste ultimul caracter
			if (ret == false) return null;
			return exp;
		}
		public static string CalculeazaExpresie(string s)
		{
			Expression exp = (new LimbajCalcStiintific()).Compileaza(ref s);
			bool compilat = exp != null;
			if (!compilat)
				return s;

			var f = Expression.Lambda<Func<double>>(exp).Compile();
			return f().ToString(CultureInfo.InvariantCulture);
		}
	}
}