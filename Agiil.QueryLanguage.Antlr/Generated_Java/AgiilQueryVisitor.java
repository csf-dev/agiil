// Generated from /home/craig/Projects/Agiil/Agiil.QueryLanguage.Antlr/Tools/../AgiilQuery.g4 by ANTLR 4.7.1
import org.antlr.v4.runtime.tree.ParseTreeVisitor;

/**
 * This interface defines a complete generic visitor for a parse tree produced
 * by {@link AgiilQueryParser}.
 *
 * @param <T> The return type of the visit operation. Use {@link Void} for
 * operations with no return type.
 */
public interface AgiilQueryVisitor<T> extends ParseTreeVisitor<T> {
	/**
	 * Visit a parse tree produced by {@link AgiilQueryParser#search}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitSearch(AgiilQueryParser.SearchContext ctx);
	/**
	 * Visit a parse tree produced by {@link AgiilQueryParser#criteria}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCriteria(AgiilQueryParser.CriteriaContext ctx);
	/**
	 * Visit a parse tree produced by {@link AgiilQueryParser#logicalcriteriagroups}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLogicalcriteriagroups(AgiilQueryParser.LogicalcriteriagroupsContext ctx);
	/**
	 * Visit a parse tree produced by {@link AgiilQueryParser#criterionorgroup}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCriterionorgroup(AgiilQueryParser.CriterionorgroupContext ctx);
	/**
	 * Visit a parse tree produced by {@link AgiilQueryParser#criteriagroup}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCriteriagroup(AgiilQueryParser.CriteriagroupContext ctx);
	/**
	 * Visit a parse tree produced by {@link AgiilQueryParser#criterion}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCriterion(AgiilQueryParser.CriterionContext ctx);
	/**
	 * Visit a parse tree produced by {@link AgiilQueryParser#elementtest}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitElementtest(AgiilQueryParser.ElementtestContext ctx);
	/**
	 * Visit a parse tree produced by {@link AgiilQueryParser#logicaloperator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLogicaloperator(AgiilQueryParser.LogicaloperatorContext ctx);
	/**
	 * Visit a parse tree produced by {@link AgiilQueryParser#element}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitElement(AgiilQueryParser.ElementContext ctx);
	/**
	 * Visit a parse tree produced by {@link AgiilQueryParser#predicate}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPredicate(AgiilQueryParser.PredicateContext ctx);
	/**
	 * Visit a parse tree produced by {@link AgiilQueryParser#predicatename}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPredicatename(AgiilQueryParser.PredicatenameContext ctx);
	/**
	 * Visit a parse tree produced by {@link AgiilQueryParser#value}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitValue(AgiilQueryParser.ValueContext ctx);
	/**
	 * Visit a parse tree produced by {@link AgiilQueryParser#constantvalue}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitConstantvalue(AgiilQueryParser.ConstantvalueContext ctx);
	/**
	 * Visit a parse tree produced by {@link AgiilQueryParser#functioninvocation}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFunctioninvocation(AgiilQueryParser.FunctioninvocationContext ctx);
	/**
	 * Visit a parse tree produced by {@link AgiilQueryParser#functionparameters}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFunctionparameters(AgiilQueryParser.FunctionparametersContext ctx);
	/**
	 * Visit a parse tree produced by {@link AgiilQueryParser#orders}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOrders(AgiilQueryParser.OrdersContext ctx);
	/**
	 * Visit a parse tree produced by {@link AgiilQueryParser#orderelement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOrderelement(AgiilQueryParser.OrderelementContext ctx);
}