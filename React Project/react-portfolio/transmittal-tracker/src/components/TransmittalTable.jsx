import { useMemo } from "react";

const API_BASE = import.meta.env.VITE_API_URL; // ASP.NET API origin

function fileUrl(attachment) {
  if (!attachment) return "";
  // already absolute?
  if (/^https?:\/\//i.test(attachment)) return attachment;
  // normalize leading slash and build absolute URL to API
  return `${API_BASE}/${String(attachment).replace(/^\/+/, "")}`;
}

export default function TransmittalTable({
  data = [],
  page, pageSize, onPageChange,
  sortBy, sortDir, onSortChange,
  isLoading, error, onEdit, onDelete
}) {
  const sorted = useMemo(() => {
    const copy = [...data];
    copy.sort((a, b) => {
      if (sortBy === "date") {
        const va = a.dateTs ?? -Infinity;
        const vb = b.dateTs ?? -Infinity;
        if (va < vb) return sortDir === "asc" ? -1 : 1;
        if (va > vb) return sortDir === "asc" ?  1 : -1;
        return 0;
      }
      const va = (a[sortBy] ?? "").toString().toLowerCase();
      const vb = (b[sortBy] ?? "").toString().toLowerCase();
      if (va < vb) return sortDir === "asc" ? -1 : 1;
      if (va > vb) return sortDir === "asc" ?  1 : -1;
      return 0;
    });
    return copy;
  }, [data, sortBy, sortDir]);

  const start = (page - 1) * pageSize;
  const pageItems = sorted.slice(start, start + pageSize);
  const total = data.length;
  const totalPages = Math.max(1, Math.ceil(total / pageSize));

  const HeaderCell = (key, label) => (
    <th
      role="button"
      onClick={() =>
        onSortChange(key, sortBy === key && sortDir === "asc" ? "desc" : "asc")
      }
    >
      {label} {sortBy === key ? (sortDir === "asc" ? "▲" : "▼") : ""}
    </th>
  );

  const formatDate = (d) => {
    if (!d) return "—";
    const ts = typeof d === "string" ? null : d;
    const date = ts ? new Date(ts) : new Date(d);
    if (Number.isNaN(date.getTime())) return "—";
    return date.toLocaleDateString("en-GB", { day: "2-digit", month: "2-digit", year: "numeric" });
  };

  if (error) return <div className="alert alert-danger">Failed to load. <button onClick={()=>location.reload()}>Retry</button></div>;
  if (isLoading) return <SkeletonRows />;

  if (!total) return <div className="text-muted">No transmittals found. Try clearing filters.</div>;

  return (
    <>
      <table className="table">
        <thead>
          <tr>
            {HeaderCell("id","ID")}
            {HeaderCell("transNo","Trans-No")}
            {HeaderCell("jobNumber","Job Number")}
            {HeaderCell("title","Title")}
            {HeaderCell("date","Date")}
            {HeaderCell("sender","Sender")}
            {HeaderCell("receiver","Receiver")}
            <th>Attachment</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {pageItems.map((x, i) => (
            <tr key={`${x.transNo}-${i}`}>
              <td>{x.id}</td>
              <td>{x.transNo}</td>
              <td>{x.jobNumber}</td>
              <td>{x.title}</td>
              <td>{formatDate(x.dateTs ?? x.date)}</td>
              <td>{x.sender}</td>
              <td>{x.receiver ?? x.recipient}</td>
              <td>
                {x.attachment ? (
                  <a
                    href={encodeURI(fileUrl(x.attachment))}
                    target="_blank"
                    rel="noopener noreferrer"
                    title="Open attachment"
                    className="btn btn-outline-primary btn-sm"
                  >
                    📎 Open
                  </a>
                ) : (
                  <span className="text-muted">—</span>
                )}
              </td>
              <td>
                <button className="btn btn-sm btn-primary me-2" onClick={() => onEdit?.(x)}>Edit</button>
                <button className="btn btn-sm btn-outline-danger" onClick={() => onDelete?.(x)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      <div className="d-flex justify-content-between align-items-center">
        <div className="text-muted">Total: {total}</div>
        <div>
          <button className="btn btn-sm btn-outline-secondary me-2" disabled={page<=1} onClick={()=>onPageChange(page-1)}>Previous</button>
          <span>Page {page} / {totalPages}</span>
          <button className="btn btn-sm btn-outline-secondary ms-2" disabled={page>=totalPages} onClick={()=>onPageChange(page+1)}>Next</button>
        </div>
      </div>
    </>
  );
}

function SkeletonRows(){
  return (
    <table className="table">
      <tbody>{Array.from({length:5}).map((_,i)=><tr key={i}><td colSpan={7}><div className="placeholder-wave"><span className="placeholder col-12"></span></div></td></tr>)}</tbody>
    </table>
  );
}
