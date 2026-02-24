const cartEvaluation = (cart) => {
  let itemsTotals = cart.map((prod) => ({
    name: prod.name,
    total: prod.price * prod.quantity,
  }));

  let overallTotal = itemsTotals.reduce((acc, cur) => acc + cur.total, 0);

  return { itemsTotals, overallTotal };
};

export default cartEvaluation;
