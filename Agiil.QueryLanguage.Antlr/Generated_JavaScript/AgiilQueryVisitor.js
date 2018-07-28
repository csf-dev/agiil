// Generated from /home/craig/Projects/Agiil/Agiil.QueryLanguage.Antlr/AgiilQuery.g4 by ANTLR 4.7.1
// jshint ignore: start
var antlr4 = require('antlr4/index');

// This class defines a complete generic visitor for a parse tree produced by AgiilQueryParser.

function AgiilQueryVisitor() {
	antlr4.tree.ParseTreeVisitor.call(this);
	return this;
}

AgiilQueryVisitor.prototype = Object.create(antlr4.tree.ParseTreeVisitor.prototype);
AgiilQueryVisitor.prototype.constructor = AgiilQueryVisitor;

// Visit a parse tree produced by AgiilQueryParser#search.
AgiilQueryVisitor.prototype.visitSearch = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by AgiilQueryParser#criteria.
AgiilQueryVisitor.prototype.visitCriteria = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by AgiilQueryParser#logicalcriteriagroups.
AgiilQueryVisitor.prototype.visitLogicalcriteriagroups = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by AgiilQueryParser#criterionorgroup.
AgiilQueryVisitor.prototype.visitCriterionorgroup = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by AgiilQueryParser#criteriagroup.
AgiilQueryVisitor.prototype.visitCriteriagroup = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by AgiilQueryParser#criterion.
AgiilQueryVisitor.prototype.visitCriterion = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by AgiilQueryParser#elementtest.
AgiilQueryVisitor.prototype.visitElementtest = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by AgiilQueryParser#logicaloperator.
AgiilQueryVisitor.prototype.visitLogicaloperator = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by AgiilQueryParser#element.
AgiilQueryVisitor.prototype.visitElement = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by AgiilQueryParser#predicate.
AgiilQueryVisitor.prototype.visitPredicate = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by AgiilQueryParser#predicatename.
AgiilQueryVisitor.prototype.visitPredicatename = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by AgiilQueryParser#value.
AgiilQueryVisitor.prototype.visitValue = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by AgiilQueryParser#constantvalue.
AgiilQueryVisitor.prototype.visitConstantvalue = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by AgiilQueryParser#functioninvocation.
AgiilQueryVisitor.prototype.visitFunctioninvocation = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by AgiilQueryParser#functionparameters.
AgiilQueryVisitor.prototype.visitFunctionparameters = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by AgiilQueryParser#orders.
AgiilQueryVisitor.prototype.visitOrders = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by AgiilQueryParser#orderelement.
AgiilQueryVisitor.prototype.visitOrderelement = function(ctx) {
  return this.visitChildren(ctx);
};



exports.AgiilQueryVisitor = AgiilQueryVisitor;