//
// Constant.cs
//
// Copyright (c) 2011 SyntaxTree
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using Microsoft.Cci.Pdb;

namespace SyntaxTree.Pdb
{
	/// <summary>
	/// Represents a constant defined in a function
	/// </summary>
	public sealed class Constant : IEquatable<Constant>
	{
		/// <summary>
		/// The name of the constant
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The primitive value of the constant
		/// </summary>
		public object Value { get; set; }

		/// <summary>
		/// The metadata token associated with the constant
		/// </summary>
		public int Token { get; set; }

		public Constant()
		{
		}

		internal Constant(PdbConstant constant)
		{
			this.Name = constant.name;
			this.Value = constant.value;
			this.Token = (int) constant.token;
		}

		public override int GetHashCode()
		{
			return this.Name.GetHashCode() ^ (this.Value == null ? -1 : this.Value.GetHashCode()) ^ this.Token;
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as Constant);
		}

		public bool Equals(Constant other)
		{
			if (other == null)
				return false;

			return this.Name == other.Name && this.Value == other.Value && this.Token == other.Token;
		}
	}
}
