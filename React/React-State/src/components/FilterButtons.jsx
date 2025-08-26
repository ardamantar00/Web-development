import { useState } from "react";

export default function FilterButtons({
  filterButton,
  setFilterButton,
  onClearItems,
}) {
  return (
    <div className=" border rounded p-3 mb-3 d-flex justify-content-between">
      <div>
        <button
          item-filter="all"
          className={`btn me-1 ${
            filterButton == "all" ? "btn-primary" : "btn-secondary"
          }`}
          onClick={() => setFilterButton("all")}
        >
          All
        </button>
        <button
          item-filter="incomplete"
          className={`btn me-1 ${
            filterButton == "incompleted" ? "btn-primary" : "btn-secondary"
          }`}
          onClick={() => setFilterButton("incompleted")}
        >
          Incomplate
        </button>
        <button
          item-filter="completed"
          className={`btn me-1 ${
            filterButton == "completed" ? "btn-primary" : "btn-secondary"
          }`}
          onClick={() => setFilterButton("completed")}
        >
          Complated
        </button>
      </div>
      <button className="btn btn-danger clear" onClick={onClearItems}>
        Clear
      </button>
    </div>
  );
}
