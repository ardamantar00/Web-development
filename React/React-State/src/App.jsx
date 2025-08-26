import "./index.css";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap-icons/font/bootstrap-icons.min.css";
import Header from "./components/Header";
import AddItemForm from "./components/AddItemForm";
import NoItem from "./components/NoItem";
import FilterButtons from "./components/FilterButtons";
import { useState } from "react";
import ListItems from "./components/ListItems";
const urunler = [
  { id: 1, name: "yumurta", completed: false },
  { id: 2, name: "peynir", completed: false },
  { id: 3, name: "süt", completed: true },
  { id: 4, name: "et", completed: true },
  { id: 5, name: "tavuk", completed: true },
];
export default function App() {
  const [items, setItems] = useState(urunler);
  const [filterButton, setFilterButton] = useState("all");

  function handleAddItem(item) {
    setItems((items) => [...items, item]);
    setFilterButton("all");
  }
  function handleDeleteItem(id) {
    setItems((items) => items.filter((i) => i.id != id));
  }
  function handleUpdateItem(id) {
    const updatedItems = (items) =>
      items.map((item) =>
        item.id == id ? { ...item, completed: !item.completed } : item
      );
    setItems(updatedItems);
  }
  function handleClearItems() {
    setItems([]);
  }
  return (
    <div className="container">
      <Header />
      <AddItemForm onAddItem={handleAddItem} />
      {items.length > 0 && (
        <FilterButtons
          filterButton={filterButton}
          setFilterButton={setFilterButton}
          onClearItems={handleClearItems}
        />
      )}

      <ListItems
        items={items}
        onDeleteItem={handleDeleteItem}
        onUpdateItem={handleUpdateItem}
        filterButton={filterButton}
      />
    </div>
  );
}
