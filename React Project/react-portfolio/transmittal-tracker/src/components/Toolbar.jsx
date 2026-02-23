import { useState, useEffect } from "react";

export default function Toolbar({ onQueryChange }) {
  const [search, setSearch] = useState("");
  const [start, setStart] = useState("");
  const [end, setEnd] = useState("");

  // debounce 300ms + deps lengkap
  useEffect(() => {
    const t = setTimeout(() => onQueryChange({ search }), 300);
    return () => clearTimeout(t);
  }, [search, onQueryChange]);   // <— tambahkan onQueryChange di sini

  const apply = () => onQueryChange({ start, end });
  const clear = () => {
    setSearch(""); setStart(""); setEnd("");
    onQueryChange({ search: "", start: "", end: "" });
  };

  return (
    <div className="d-flex gap-2 align-items-end table-filter">
      <input className="form-control" placeholder="Search No., Job, Sender, Receiver" value={search} onChange={e=>setSearch(e.target.value)} />
      <div>
        <label className="form-label">From</label>
        <input type="date" className="form-control" value={start} onChange={e=>setStart(e.target.value)} />
      </div>
      <div>
        <label className="form-label">To</label>
        <input type="date" className="form-control" value={end} onChange={e=>setEnd(e.target.value)} />
      </div>
      <button className="btn btn-primary" onClick={apply}>Filter</button>
      <button className="btn btn-outline-secondary" onClick={clear}>Clear</button>
    </div>
  );
}
