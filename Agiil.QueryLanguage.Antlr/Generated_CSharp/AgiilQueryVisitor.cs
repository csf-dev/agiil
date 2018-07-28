//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/craig/Projects/Agiil/Agiil.QueryLanguage.Antlr/AgiilQuery.g4 by ANTLR 4.7.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Agiil.QueryLanguage {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="AgiilQueryParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public interface IAgiilQueryVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="AgiilQueryParser.search"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSearch([NotNull] AgiilQueryParser.SearchContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AgiilQueryParser.criteria"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCriteria([NotNull] AgiilQueryParser.CriteriaContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AgiilQueryParser.logicalcriteriagroups"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicalcriteriagroups([NotNull] AgiilQueryParser.LogicalcriteriagroupsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AgiilQueryParser.criterionorgroup"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCriterionorgroup([NotNull] AgiilQueryParser.CriterionorgroupContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AgiilQueryParser.criteriagroup"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCriteriagroup([NotNull] AgiilQueryParser.CriteriagroupContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AgiilQueryParser.criterion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCriterion([NotNull] AgiilQueryParser.CriterionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AgiilQueryParser.elementtest"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElementtest([NotNull] AgiilQueryParser.ElementtestContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AgiilQueryParser.logicaloperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicaloperator([NotNull] AgiilQueryParser.LogicaloperatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AgiilQueryParser.element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElement([NotNull] AgiilQueryParser.ElementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AgiilQueryParser.predicate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPredicate([NotNull] AgiilQueryParser.PredicateContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AgiilQueryParser.predicatename"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPredicatename([NotNull] AgiilQueryParser.PredicatenameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AgiilQueryParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitValue([NotNull] AgiilQueryParser.ValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AgiilQueryParser.constantvalue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstantvalue([NotNull] AgiilQueryParser.ConstantvalueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AgiilQueryParser.functioninvocation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctioninvocation([NotNull] AgiilQueryParser.FunctioninvocationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AgiilQueryParser.functionparameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionparameters([NotNull] AgiilQueryParser.FunctionparametersContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AgiilQueryParser.orders"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOrders([NotNull] AgiilQueryParser.OrdersContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AgiilQueryParser.orderelement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOrderelement([NotNull] AgiilQueryParser.OrderelementContext context);
}
} // namespace Agiil.QueryLanguage
